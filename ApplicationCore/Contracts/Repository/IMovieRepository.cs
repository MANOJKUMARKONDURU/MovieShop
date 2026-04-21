using ApplicationCore.Entities;
using System.Collections.Generic;

namespace ApplicationCore.Contracts.Repository
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> GetTopMovies(int count);
        IEnumerable<Movie> GetHighestGrossingMovies(int count);
        
    }
}