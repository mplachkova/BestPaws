namespace BestPaws.Services.Data
{
    using System.Threading.Tasks;

    using BestPaws.Web.ViewModels.PetCenter;

    public interface IAddPetService
    {
        Task CreateAsync(AddPetInputModel input);
    }
}
