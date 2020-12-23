namespace BestPaws.Web.ViewModels.Doctor
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using BestPaws.Data.Models;
    using BestPaws.Services.Mapping;

    public class DoctorInputModel : IMapFrom<Doctor>, IHaveCustomMappings
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string MiddleName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Specialization { get; set; }

        [Required]
        [MinLength(10)]
        public string Biography { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Doctor, DoctorInputModel>();
        }
    }
}
