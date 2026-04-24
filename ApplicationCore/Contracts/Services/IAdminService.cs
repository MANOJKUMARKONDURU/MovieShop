using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IAdminService
    {
        Task GenerateDailyReportAsync();
    }
}