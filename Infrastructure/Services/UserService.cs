using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> RegisterUserAsync(string email, string password)
        {
            var existing = await _userRepository.GetByEmailAsync(email);
            if (existing != null) return false;

            var user = new User
            {
                Email = email,
                HashedPassword = password,
                Salt = ""
            };

            await _userRepository.AddAsync(user);
            return true;
        }
    }
}