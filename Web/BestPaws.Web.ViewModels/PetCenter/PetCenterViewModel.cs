namespace BestPaws.Web.ViewModels
{
    using AutoMapper;
    using BestPaws.Data.Models;
    using BestPaws.Services.Mapping;

    public class PetCenterViewModel : IMapFrom<Pet>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public byte Age { get; set; }

        public string Gender { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Pet, PetCenterViewModel>();
        }
    }
}
