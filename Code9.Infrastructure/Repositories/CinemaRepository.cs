using Code9.Domain.Interfaces;
using Code9.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Code9.Infrastructure.Repositories
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly CinemaDbContext _dbContext;

        public CinemaRepository(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cinema>> AddCinema(Cinema cinema)
        {
            await _dbContext.Cinemas.AddAsync(cinema);

            await _dbContext.SaveChangesAsync();

            return await _dbContext.Cinemas.ToListAsync();
        }

        public async Task<List<Cinema>> GetAllCinemas()
        {
            return await _dbContext.Cinemas.ToListAsync();
        }

        public async Task<List<Cinema>> UpdateCinema(Cinema cinema)
        {
           Cinema toUpdate = await _dbContext.Cinemas.FirstOrDefaultAsync(c => cinema.Id == c.Id);

            toUpdate.Name = cinema.Name;
            toUpdate.Street = cinema.Street;
            toUpdate.NumberOfAuditoriums = cinema.NumberOfAuditoriums;
            toUpdate.City = cinema.City; 

            await _dbContext.SaveChangesAsync();

            return await _dbContext.Cinemas.ToListAsync();
        }
    }
}