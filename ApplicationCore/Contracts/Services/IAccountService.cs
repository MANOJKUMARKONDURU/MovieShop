using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string email, string password);
        Task LogoutAsync();
    }
}