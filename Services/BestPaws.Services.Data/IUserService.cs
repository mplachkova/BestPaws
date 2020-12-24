namespace BestPaws.Services.Data
{
    using System.Threading.Tasks;

    using BestPaws.Web.ViewModels.PetCenter;

    public interface IUserService
    {
        Task CreateUserAsync(AddPetInputModel model);
    }
}
