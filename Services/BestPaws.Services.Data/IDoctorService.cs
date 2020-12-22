namespace BestPaws.Services.Data
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IDoctorService
    {
        IEnumerable<SelectListItem> GetAllDoctors();
    }
}
