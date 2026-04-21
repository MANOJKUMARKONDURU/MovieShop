using ApplicationCore.Entities;
using System.Collections.Generic;

namespace ApplicationCore.Contracts.Services
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres();
    }
}