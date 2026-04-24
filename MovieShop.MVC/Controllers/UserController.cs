using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPurchaseRepository _purchaseRepository;

        public UserController(IUserService userService, IPurchaseRepository purchaseRepository)
        {
            _userService = userService;
            _purchaseRepository = purchaseRepository;
        }

        public async Task<IActionResult> Purchases(int userId)
        {
            var purchases = await _purchaseRepository.GetPurchasesByUserAsync(userId);
            return View(purchases);
        }
    }
}