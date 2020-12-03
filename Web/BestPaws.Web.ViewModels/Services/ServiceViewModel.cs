namespace BestPaws.Web.ViewModels.Services
{
    using AutoMapper;
    using BestPaws.Data.Models;
    using BestPaws.Services.Mapping;

    public class ServiceViewModel : IMapFrom<Service>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Service, ServiceViewModel>();
        }
    }
}
