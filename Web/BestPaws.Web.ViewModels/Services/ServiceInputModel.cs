namespace BestPaws.Web.ViewModels.Services
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using BestPaws.Data.Models;
    using BestPaws.Services.Mapping;

    public class ServiceInputModel : IMapFrom<Service>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        public string Name { get; set; }

        [Required]
        [MinLength(30)]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Service, ServiceInputModel>();
        }
    }
}
