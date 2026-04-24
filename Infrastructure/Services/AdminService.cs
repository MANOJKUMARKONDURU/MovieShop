using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AdminService : IAdminService
    {
        private readonly IReportRepository _reportRepository;

        public AdminService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task GenerateDailyReportAsync()
        {
            var reports = await _reportRepository.GetAllAsync();

         
        }
    }
}