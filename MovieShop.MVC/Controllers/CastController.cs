using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService _castService;

        public CastController(ICastService castService)
        {
            _castService = castService;
        }

        public IActionResult Details(int id)
        {
            var cast = _castService.GetCastDetails(id);
            if (cast == null)
            {
                return NotFound();
            }

            return View(cast);
        }
    }
}