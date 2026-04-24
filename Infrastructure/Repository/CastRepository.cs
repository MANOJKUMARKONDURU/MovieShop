using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CastRepository : Repository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Cast> GetCastWithMoviesAsync(int id)
        {
            return await _dbContext.Casts
                .Include(c => c.MovieCasts)
                .ThenInclude(mc => mc.Movie)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<Cast> GetByIdAsync(int id)
        {
            return await GetCastWithMoviesAsync(id);
        }
    }
}