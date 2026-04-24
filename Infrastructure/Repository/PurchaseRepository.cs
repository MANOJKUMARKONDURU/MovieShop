using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Purchase>> GetPurchasesByUserAsync(int userId)
        {
            return await _dbContext.Purchases
                .Where(p => p.UserId == userId)
                .Include(p => p.Movie)
                .ToListAsync();
        }
    }
}