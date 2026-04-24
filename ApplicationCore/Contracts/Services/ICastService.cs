using ApplicationCore.Models;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface ICastService
    {
        Task<CastDetailsModel> GetCastDetailsAsync(int id);
    }
}