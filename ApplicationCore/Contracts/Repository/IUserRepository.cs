using ApplicationCore.Entities;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}