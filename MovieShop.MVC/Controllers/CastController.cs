using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService _castService;

        public CastController(ICastService castService)
        {
            _castService = castService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var cast = await _castService.GetCastDetailsAsync(id);
            if (cast == null)
            {
                return NotFound();
            }

            return View(cast);
        }
    }
}