namespace BestPaws.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BestPaws.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class DoctorSeeder : ISeeder
    {
        private const string BiographyFemale = @" was born and raised in Sofia.
            She attended the University of Forestry, Sofia where he received his degree in Veterinary Medicine.
            Her interesta are in Infectious and Parasitic Diseases and Surgery.
            Doctor X is fond of skeeing and likes to spend her free time with her family and friends";

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Doctors.Any())
            {
                return;
            }

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            await SeedDoctorAsync(userManager, "doctor@abv.bg");
        }

        private static async Task SeedDoctorAsync(UserManager<ApplicationUser> userManager, string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user != null)
            {
                if (user.Doctor == null)
                {
                    var doctor = new Doctor
                    {
                        Id = user.Id,
                        FirstName = "Maria",
                        MiddleName = "Ivanova",
                        LastName = "Popova",
                        Specialization = "Infectious and Parasitic Diseases",
                    };
                    doctor.Biography = string.Format("{0}" + BiographyFemale, doctor.LastName);
                    user.Doctor = doctor;
                }
            }
        }
    }
}
