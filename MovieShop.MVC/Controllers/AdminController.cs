using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult GenerateReport()
        {
            _adminService.GenerateDailyReport();
            ViewBag.Message = "Report generated successfully.";
            return View();
        }
    }
}