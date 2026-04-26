using System;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(string email, string password, string firstName, string lastName, DateTime? dateOfBirth);
    }
}