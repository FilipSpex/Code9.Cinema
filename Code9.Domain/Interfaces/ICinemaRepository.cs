using Code9.Domain.Models;

namespace Code9.Domain.Interfaces
{
    public interface ICinemaRepository
    {
        public Task<List<Cinema>> GetAllCinemas();
        public Task<List<Cinema>> UpdateCinema(Cinema cinema);
        public Task<List<Cinema>> AddCinema(Cinema cinema);
    }
}
