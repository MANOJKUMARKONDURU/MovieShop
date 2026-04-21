using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool RegisterUser(string email, string password)
        {
            var existing = _userRepository.GetByEmail(email);
            if (existing != null) return false;

            var user = new User
            {
                Email = email,
                HashedPassword = password,
                Salt = ""
            };

            _userRepository.Add(user);
            return true;
        }
    }
}