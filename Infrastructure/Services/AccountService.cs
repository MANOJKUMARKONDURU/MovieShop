using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Login(string email, string password)
        {
            var user = _userRepository.GetByEmail(email);
            if (user == null) return false;

            return user.HashedPassword == password;
        }

        public void Logout()
        {
            // No-op for now
        }
    }
}