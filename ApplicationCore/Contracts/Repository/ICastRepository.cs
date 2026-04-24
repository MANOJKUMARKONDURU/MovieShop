using ApplicationCore.Entities;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repository
{
    public interface ICastRepository : IRepository<Cast>
    {
        Task<Cast> GetCastWithMoviesAsync(int id);
    }
}