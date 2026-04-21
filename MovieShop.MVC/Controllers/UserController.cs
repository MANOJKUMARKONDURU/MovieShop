using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Purchases(int userId)
        {
            var purchases = _purchaseRepository.GetPurchasesByUser(userId);
            return View(purchases);
        }
    }
}