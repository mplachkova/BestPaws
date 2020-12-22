namespace BestPaws.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using BestPaws.Data.Common.Repositories;
    using BestPaws.Data.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class DoctorService : IDoctorService
    {
        private readonly IDeletableEntityRepository<Doctor> doctorRepository;

        public DoctorService(IDeletableEntityRepository<Doctor> repository)
        {
            this.doctorRepository = repository;
        }

        public IEnumerable<SelectListItem> GetAllDoctors()
        {
            var doctorsList = this.doctorRepository
                .AllAsNoTracking()
                .Select(x => new SelectListItem
                {
                    Text = x.FirstName + " " + x.LastName,
                    Value = x.Id,
                })
                .ToList();
            return doctorsList;
        }
    }
}
