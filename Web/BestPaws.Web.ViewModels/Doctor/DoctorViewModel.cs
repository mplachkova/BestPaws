namespace BestPaws.Web.ViewModels.Doctor
{
    using AutoMapper;
    using BestPaws.Data.Models;
    using BestPaws.Services.Mapping;

    public class DoctorViewModel : IMapFrom<Doctor>, IHaveCustomMappings
    {

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string ApplicationUserId { get; set; }

        public string Specialization { get; set; }

        public string Biography { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Doctor, DoctorViewModel>();
        }
    }
}
