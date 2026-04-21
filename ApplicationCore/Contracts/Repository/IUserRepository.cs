using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
    }
}