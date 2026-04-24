using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> GenerateReport()
        {
            await _adminService.GenerateDailyReportAsync();
            ViewBag.Message = "Report generated successfully.";
            return View();
        }
    }
}