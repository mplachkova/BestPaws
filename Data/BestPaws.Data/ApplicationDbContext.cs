namespace BestPaws.Data
{
    // New version
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using BestPaws.Data.Common.Models;
    using BestPaws.Data.Models;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<AnimalBreed> AnimalBreeds { get; set; }

        public DbSet<AnimalType> AnimalTypes { get; set; }

        public DbSet<Diagnosis> Diagnoses { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<PetOwner> PetOwners { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<MedicamentsPrescriptions> MedicamentsPrescriptions { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<PetsDiagnoses> PetsDiagnoses { get; set; }

        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<ReferenceValue> ReferenceValues { get; set; }

        public DbSet<TestIndicator> TestIndicators { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Treatment> Treatments { get; set; }

        public DbSet<PetsTreatments> PetsTreatments { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Creating Many to many relations
            builder.Entity<PetsDiagnoses>(entity =>
            {
                entity.HasKey(pd => new
                {
                    pd.PetId,
                    pd.DiagnosisId,
                });

                entity.HasOne(pd => pd.Pet)
                .WithMany(p => p.PetsDiagnoses)
                .HasForeignKey(pd => pd.PetId);

                entity.HasOne(pd => pd.Diagnosis)
                .WithMany(d => d.DiagnosesPets)
                .HasForeignKey(pd => pd.DiagnosisId);
            });

            builder.Entity<MedicamentsPrescriptions>(entity =>
            {
                entity.HasKey(mp => new
                {
                    mp.MedicamentId,
                    mp.PrescriptionId,
                });

                entity.HasOne(mp => mp.Medicament)
                .WithMany(m => m.MedicamentsPrescriptions)
                .HasForeignKey(mp => mp.MedicamentId);

                entity.HasOne(mp => mp.Prescription)
                .WithMany(p => p.PrescriptionsMedicaments)
                .HasForeignKey(mp => mp.PrescriptionId);
            });

            builder.Entity<PetsTreatments>(entity =>
           {
               entity.HasKey(pt => new
               {
                   pt.PetId,
                   pt.TreatmentId,
               });

               entity.HasOne(pt => pt.Pet)
               .WithMany(p => p.PetsTreatments)
               .HasForeignKey(pt => pt.PetId);

               entity.HasOne(pt => pt.Treatment)
               .WithMany(p => p.PetsTreatments)
               .HasForeignKey(pt => pt.TreatmentId);
           });
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
