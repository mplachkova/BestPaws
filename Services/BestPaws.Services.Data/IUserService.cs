namespace BestPaws.Services.Data
{
    using System.Threading.Tasks;

    using BestPaws.Web.ViewModels.PetCenter;
    using BestPaws.Web.ViewModels.Users;

    public interface IUserService
    {
        Task CreatePetOwnerAsync(AddPetInputModel model);

        Task CreateAdminAsync(UserInputModel input);
    }
}
