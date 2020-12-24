namespace BestPaws.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BestPaws.Data.Common.Repositories;
    using BestPaws.Data.Models;
    using BestPaws.Services.Mapping;
    using BestPaws.Web.ViewModels.Doctor;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.Extensions.DependencyInjection;

    public class DoctorService : IDoctorService
    {
        private readonly IDeletableEntityRepository<Doctor> doctorRepository;
        private readonly IServiceProvider serviceProvider;

        public DoctorService(IDeletableEntityRepository<Doctor> repository, IServiceProvider provider)
        {
            this.doctorRepository = repository;
            this.serviceProvider = provider;
        }

        public async Task AddDoctor(DoctorInputModel inputModel)
        {
            var userManager = this.serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var user = new ApplicationUser
            {
                UserName = inputModel.LastName + "@bestpaws.eu",
                Email = inputModel.LastName + "@bestpaws.eu",
                Doctor = new Doctor
                {
                    FirstName = inputModel.FirstName,
                    MiddleName = inputModel.MiddleName,
                    LastName = inputModel.LastName,
                    Specialization = inputModel.Specialization,
                    Biography = inputModel.Biography,
                },
            };

            var password = this.GeneratePassword(user.UserName);

            IdentityResult result = new IdentityResult();

            result = userManager.CreateAsync(user, password).Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Doctor");
            }

            await this.doctorRepository.SaveChangesAsync();
        }

        public DoctorInputModel GetDoctorById(string id)
        {
            var doctor = this.doctorRepository
                .AllWithDeleted()
                .To<DoctorInputModel>()
                .FirstOrDefault(x => x.Id == id);
            return doctor;
        }

        public IEnumerable<SelectListItem> GetAllDoctorsFirstAndLastName()
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

        public IEnumerable<T> GetAll<T>()
        {
            var result = this.doctorRepository.All().To<T>().ToList();
            return result;
        }

        public IEnumerable<T> GetAllWithDeleted<T>()
        {
            var doctorsList = this.doctorRepository
               .AllWithDeleted()
               .To<T>()
               .ToList();
            return doctorsList;
        }

        public async Task EditAsync(string id, DoctorInputModel model)
        {
            var editedDoctor = this.doctorRepository
                .AllWithDeleted()
                .FirstOrDefault(x => x.Id == id);
            editedDoctor.FirstName = model.FirstName;
            editedDoctor.MiddleName = model.MiddleName;
            editedDoctor.LastName = model.LastName;
            editedDoctor.Biography = model.Biography;
            editedDoctor.Specialization = model.Specialization;

            await this.doctorRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var doctorToDelete = this.doctorRepository
                .All()
                .FirstOrDefault(x => x.Id == id);
            this.doctorRepository.Delete(doctorToDelete);
            await this.doctorRepository.SaveChangesAsync();
        }

        public async Task RestoreAsync(string id)
        {
            var serviceToRestore = this.doctorRepository.AllWithDeleted().FirstOrDefault(x => x.Id == id);
            serviceToRestore.IsDeleted = false;
            await this.doctorRepository.SaveChangesAsync();
        }

        private string GeneratePassword(string input)
        {
            int passwordLength = input.IndexOf("@");
            string passwordString = input.Substring(0, passwordLength) + "12345";
            return passwordString;
        }
    }
}
