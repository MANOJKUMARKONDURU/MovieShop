using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly MovieShopDbContext _dbContext;

        public GenreService(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _dbContext.Genres.ToList();
        }
    }
}