using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Movie> GetTopMovies(int count)
        {
            return _dbContext.Movies
                .OrderByDescending(m => m.Revenue)
                .Take(count)
                .ToList();
        }

        public IEnumerable<Movie> GetHighestGrossingMovies(int count)
        {
            return _dbContext.Movies
                .OrderByDescending(m => m.Revenue)
                .Take(count)
                .ToList();
        }

        public override Movie GetById(int id)
        {
            return _dbContext.Movies
                .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
                .Include(m => m.Trailers)
                .Include(m => m.MovieCasts).ThenInclude(mc => mc.Cast)
                .Include(m => m.MovieCrews).ThenInclude(mc => mc.Crew)
                .FirstOrDefault(m => m.Id == id);
        }
        
        
    }
}