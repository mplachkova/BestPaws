namespace BestPaws.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BestPaws.Data.Models;
    using BestPaws.Web.ViewModels.Doctor;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IDoctorService
    {
        Task AddDoctor(DoctorInputModel inputModel);

        DoctorInputModel GetDoctorById(string id);

        IEnumerable<SelectListItem> GetAllDoctorsFirstAndLastName();

        IEnumerable<T> GetAll<T>();

        IEnumerable<SelectListItem> GetAllWithDeleted();

        Task EditAsync(string id, DoctorInputModel model);

        Task DeleteAsync(string id);

        Task RestoreAsync(string id);
    }
}
