namespace BestPaws.Web.ViewModels.PetCenter
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;
    using BestPaws.Data.Models;
    using BestPaws.Services.Mapping;

    public class PetCenterViewMode : IMapFrom<Pet>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public PetOwner PetOwner { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Name { get; set; }

        public byte Age { get; set; }

        public string Gender { get; set; }

        public Doctor Doctor { get; set; }

        public AnimalType AnimalType { get; set; }

        public AnimalBreed AnimalBreed { get; set; }

        public ICollection<PetsDiagnoses> PetsDiagnoses { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }

        public ICollection<Test> Tests { get; set; }

        public ICollection<PetsTreatments> PetsTreatments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Pet, PetCenterViewMode>();
        }
    }
}
