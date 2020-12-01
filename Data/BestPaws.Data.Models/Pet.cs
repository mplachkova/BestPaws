﻿namespace BestPaws.Data.Models
{
    using System.Collections.Generic;

    using BestPaws.Data.Common.Models;

    public class Pet : BaseDeletableModel<int>
    {
        public Pet()
        {
            this.Prescriptions = new HashSet<Prescription>();
            this.PetsDiagnoses = new HashSet<PetsDiagnoses>();
            this.Tests = new HashSet<Test>();
        }

        public string Name { get; set; }

        public byte Age { get; set; }

        public string Gender { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        public AnimalType AnimalType { get; set; }

        public int AnimalTypeId { get; set; }

        public AnimalBreed AnimalBreed { get; set; }

        public int? AnimalBreedId { get; set; }

        public ICollection<PetsDiagnoses> PetsDiagnoses { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }

        public ICollection<Test> Tests { get; set; }
    }
}