using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieCardResponseModel>> GetTopMoviesAsync(int count);
        Task<MovieDetailsModel> GetMovieDetailsAsync(int id);
        Task<IEnumerable<MovieCardResponseModel>> GetMoviesByGenreAsync(int genreId);
        Task<MoviePagedResultModel> GetPagedMoviesAsync(int pageNumber, int pageSize);
        Task<MoviePagedResultModel> GetPagedMoviesByGenreAsync(int genreId, int pageNumber, int pageSize);

    }
}