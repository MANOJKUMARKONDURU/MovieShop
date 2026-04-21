using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            var movies = _movieService.GetTopMovies(150);
            return View(movies);
        }
    }
}