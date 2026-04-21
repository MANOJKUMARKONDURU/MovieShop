using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repository
{
    public class CastRepository : Repository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public Cast GetCastWithMovies(int id)
        {
            return _dbContext.Casts
                .Include(c => c.MovieCasts)
                .ThenInclude(mc => mc.Movie)
                .FirstOrDefault(c => c.Id == id);
        }

        public override Cast GetById(int id)
        {
            return GetCastWithMovies(id);
        }
    }
}