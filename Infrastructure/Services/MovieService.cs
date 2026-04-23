using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetTopMoviesAsync(int count)
        {
            var movies = await _movieRepository.GetHighestGrossingMoviesAsync(count);

            return movies.Select(m => new MovieCardResponseModel
            {
                Id = m.Id,
                Title = m.Title,
                PosterUrl = m.PosterUrl
            }).ToList();
        }

        public async Task<MovieDetailsModel> GetMovieDetailsAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null) return null;

            return new MovieDetailsModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Overview = movie.Overview,
                PosterUrl = movie.PosterUrl,
                Revenue = movie.Revenue,
                Rating = movie.Rating,
                Genres = movie.MovieGenres.Select(g => g.Genre.Name).ToList(),
                Trailers = movie.Trailers.Select(t => (t.Name, t.TrailerUrl)).ToList(),
                Casts = movie.MovieCasts
                    .Select(mc => (mc.CastId, mc.Cast.Name, mc.Character, mc.Cast.ProfilePath))
                    .ToList()
            };
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetMoviesByGenreAsync(int genreId)
        {
            var movies = await _movieRepository.GetMoviesByGenreAsync(genreId);

            return movies.Select(m => new MovieCardResponseModel
            {
                Id = m.Id,
                Title = m.Title,
                PosterUrl = m.PosterUrl
            }).ToList();
        }
        public async Task<MoviePagedResultModel> GetPagedMoviesAsync(int pageNumber, int pageSize)
        {
            var movies = await _movieRepository.GetMoviesPagedAsync(pageNumber, pageSize);
            var totalCount = await _movieRepository.GetTotalMoviesCountAsync();

            return new MoviePagedResultModel
            {
                Movies = movies.Select(m => new MovieCardResponseModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    PosterUrl = m.PosterUrl
                }),
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalMovies = totalCount
            };
        }

        public async Task<MoviePagedResultModel> GetPagedMoviesByGenreAsync(int genreId, int pageNumber, int pageSize)
        {
            var movies = await _movieRepository.GetMoviesByGenrePagedAsync(genreId, pageNumber, pageSize);
            var totalCount = await _movieRepository.GetTotalMoviesByGenreCountAsync(genreId);

            return new MoviePagedResultModel
            {
                Movies = movies.Select(m => new MovieCardResponseModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    PosterUrl = m.PosterUrl
                }),
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalMovies = totalCount
            };
        }

    }
}
