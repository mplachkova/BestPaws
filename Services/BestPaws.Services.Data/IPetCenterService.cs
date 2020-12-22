namespace BestPaws.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BestPaws.Web.ViewModels.PetCenter;

    public interface IPetCenterService
    {
        IEnumerable<T> GetAll<T>();

        Task CreateAsync(AddPetInputModel input);
    }
}
