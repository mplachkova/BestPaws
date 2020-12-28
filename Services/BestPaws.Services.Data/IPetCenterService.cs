namespace BestPaws.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BestPaws.Web.ViewModels.PetCenter;

    public interface IPetCenterService
    {
        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllForCurrentUser<T>(string id);

        Task CreateAsync(AddPetInputModel input);

        PetCenterViewMode GellAllPetInfo(int id);

        string GetPetName(int id);
    }
}
