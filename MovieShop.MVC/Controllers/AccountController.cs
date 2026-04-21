using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public AccountController(IAccountService accountService, IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (_accountService.Login(email, password))
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid login.";
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string email, string password)
        {
            if (_userService.RegisterUser(email, password))
            {
                return RedirectToAction("Login");
            }

            ViewBag.Error = "User already exists.";
            return View();
        }

        public IActionResult Logout()
        {
            _accountService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}