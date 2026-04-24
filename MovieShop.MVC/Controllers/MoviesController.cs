using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;

        public MoviesController(IMovieService movieService, IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieDetailsAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // Genre page with pagination
        public async Task<IActionResult> Genre(int id, int page = 1)
        {
            // 20 movies per page
            var model = await _movieService.GetPagedMoviesByGenreAsync(id, page, 20);

            // FIXED: async genre lookup
            var genres = await _genreService.GetAllGenresAsync();
            var genre = genres.FirstOrDefault(g => g.Id == id);

            ViewBag.GenreName = genre?.Name ?? "Movies";
            ViewBag.GenreId = id;

            return View("GenreMovies", model);
        }
    }
}