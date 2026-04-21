using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IEnumerable<MovieCardModel> GetTopMovies(int count)
        {
            var movies = _movieRepository.GetHighestGrossingMovies(count);

            return movies.Select(m => new MovieCardModel
            {
                Id = m.Id,
                Title = m.Title,
                PosterUrl = m.PosterUrl,
                Price = 9.99m
            }).ToList();
        }

        public MovieDetailsModel GetMovieDetails(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null) return null;

            return new MovieDetailsModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Overview = movie.Overview,
                PosterUrl = movie.PosterUrl,
                Revenue = movie.Revenue,
                Genres = movie.MovieGenres.Select(g => g.Genre.Name).ToList(),
                Trailers = movie.Trailers.Select(t => (t.Name, t.TrailerUrl)).ToList(),
                Casts = movie.MovieCasts
                    .Select(mc => (mc.CastId, mc.Cast.Name, mc.Character, mc.Cast.ProfilePath))
                    .ToList()
            };
        }

        public IEnumerable<MovieCardResponseModel> GetMoviesByGenre(int genreId)
        {
            throw new NotImplementedException();
        }
    }
}