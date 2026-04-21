using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}