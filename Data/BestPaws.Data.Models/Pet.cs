namespace BestPaws.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BestPaws.Data.Common.Models;

    public class Pet : BaseDeletableModel<int>
    {
        public Pet()
        {
            this.Prescriptions = new HashSet<Prescription>();
            this.PetsDiagnoses = new HashSet<PetsDiagnoses>();
            this.Tests = new HashSet<Test>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public byte Age { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        [Required]
        public AnimalType AnimalType { get; set; }

        public int AnimalTypeId { get; set; }

        [Required]
        public AnimalBreed AnimalBreed { get; set; }

        public int AnimalBreedId { get; set; }

        public ICollection<PetsDiagnoses> PetsDiagnoses { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }

        public ICollection<Test> Tests { get; set; }
    }
}
