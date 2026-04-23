using ApplicationCore.Entities;
using System.Collections.Generic;

namespace ApplicationCore.Contracts.Repository
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetTopMoviesAsync(int count);
        Task<IEnumerable<Movie>> GetHighestGrossingMoviesAsync(int count);
        Task<Movie> GetByIdAsync(int id); Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId);
        
        Task<IEnumerable<Movie>> GetMoviesPagedAsync(int pageNumber, int pageSize);
        Task<int> GetTotalMoviesCountAsync();

        Task<IEnumerable<Movie>> GetMoviesByGenrePagedAsync(int genreId, int pageNumber, int pageSize);
        Task<int> GetTotalMoviesByGenreCountAsync(int genreId);

    }
}