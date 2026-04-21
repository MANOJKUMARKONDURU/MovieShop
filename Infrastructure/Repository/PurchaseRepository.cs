using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Purchase> GetPurchasesByUser(int userId)
        {
            return _dbContext.Purchases
                .Where(p => p.UserId == userId)
                .ToList();
        }
    }
}