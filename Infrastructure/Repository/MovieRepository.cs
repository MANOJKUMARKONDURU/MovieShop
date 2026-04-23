using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetTopMoviesAsync(int count)
        {
            return await _dbContext.Movies
                .OrderByDescending(m => m.Revenue)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetHighestGrossingMoviesAsync(int count)
        {
            return await _dbContext.Movies
                .OrderByDescending(m => m.Revenue)
                .Take(count)
                .ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _dbContext.Movies
                .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
                .Include(m => m.Trailers)
                .Include(m => m.MovieCasts).ThenInclude(mc => mc.Cast)
                .Include(m => m.MovieCrews).ThenInclude(mc => mc.Crew)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId)
        {
            return await _dbContext.Movies
                .Include(m => m.MovieGenres)
                .Where(m => m.MovieGenres.Any(g => g.GenreId == genreId))
                .ToListAsync();
        }
        public async Task<IEnumerable<Movie>> GetMoviesPagedAsync(int pageNumber, int pageSize)
        {
            return await _dbContext.Movies
                .OrderBy(m => m.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalMoviesCountAsync()
        {
            return await _dbContext.Movies.CountAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenrePagedAsync(int genreId, int pageNumber, int pageSize)
        {
            return await _dbContext.Movies
                .Include(m => m.MovieGenres)
                .Where(m => m.MovieGenres.Any(g => g.GenreId == genreId))
                .OrderBy(m => m.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalMoviesByGenreCountAsync(int genreId)
        {
            return await _dbContext.Movies
                .Include(m => m.MovieGenres)
                .Where(m => m.MovieGenres.Any(g => g.GenreId == genreId))
                .CountAsync();
        }

    }
}