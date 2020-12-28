namespace BestPaws.Web.ViewModels.Treatments
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;
    using BestPaws.Data.Models;
    using BestPaws.Services.Mapping;

    public class TreatmentViewModel : IMapFrom<Treatment>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public ICollection<PetsTreatments> PetsTreatments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Treatment, TreatmentViewModel>();
            configuration.CreateMap<PetsTreatments, TreatmentViewModel>();
        }
    }
}
