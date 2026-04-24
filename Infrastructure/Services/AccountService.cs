using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null) return false;

            return user.HashedPassword == password;
        }

        public Task LogoutAsync()
        {
            // No-op for now
            return Task.CompletedTask;
        }
    }
}