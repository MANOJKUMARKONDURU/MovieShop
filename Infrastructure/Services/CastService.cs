using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<CastDetailsModel> GetCastDetailsAsync(int id)
        {
            var cast = await _castRepository.GetCastWithMoviesAsync(id);
            if (cast == null) return null;

            return new CastDetailsModel
            {
                Id = cast.Id,
                Name = cast.Name,
                ProfilePath = cast.ProfilePath,
                Movies = cast.MovieCasts
                    .Select(mc => (mc.MovieId, mc.Movie.Title, mc.Character))
                    .ToList()
            };
        }
    }
}