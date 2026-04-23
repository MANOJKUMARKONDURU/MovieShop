using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // Home Page with Pagination
        public async Task<IActionResult> Index(int page = 1)
        {
            // 20 movies per page
            var model = await _movieService.GetPagedMoviesAsync(page, 20);
            return View(model);
        }
    }
}