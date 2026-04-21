using ApplicationCore.Entities;
using System.Collections.Generic;

namespace ApplicationCore.Contracts.Repository
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        IEnumerable<Purchase> GetPurchasesByUser(int userId);
    }
}