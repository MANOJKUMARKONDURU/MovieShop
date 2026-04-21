using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;

namespace Infrastructure.Services
{
    public class AdminService : IAdminService
    {
        private readonly IReportRepository _reportRepository;

        public AdminService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public void GenerateDailyReport()
        {
            var reports = _reportRepository.GetAll();
           
        }
    }
}