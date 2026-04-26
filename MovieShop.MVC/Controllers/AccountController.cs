using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShop.MVC.Models;

namespace MovieShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public AccountController(IUserService userService, IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var success = await _accountService.LoginAsync(model.Email, model.Password);
            if (!success)
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var success = await _userService.RegisterUserAsync(
                model.Email,
                model.Password,
                model.FirstName,
                model.LastName,
                model.DateOfBirth);

            if (!success)
            {
                ModelState.AddModelError("", "Email already exists");
                return View(model);
            }

            // After registration, redirect to Login
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
