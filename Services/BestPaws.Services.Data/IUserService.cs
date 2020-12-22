namespace BestPaws.Services.Data
{
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task CreateUserAsync(string userName);
    }
}
