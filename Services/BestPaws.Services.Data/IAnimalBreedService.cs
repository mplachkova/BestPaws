namespace BestPaws.Services.Data
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IAnimalBreedService
    {
        IEnumerable<SelectListItem> GetAllAnimalBreeds();
    }
}
