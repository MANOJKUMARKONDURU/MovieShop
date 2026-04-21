using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repository
{
    public interface ICastRepository : IRepository<Cast>
    {
        // Override GetById to include Movies
        Cast GetCastWithMovies(int id);
    }
}