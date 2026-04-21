using ApplicationCore.Models;
using System.Collections.Generic;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        IEnumerable<MovieCardModel> GetTopMovies(int count);
        MovieDetailsModel GetMovieDetails(int id);
        IEnumerable<MovieCardResponseModel> GetMoviesByGenre(int genreId);

    }
}