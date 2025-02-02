using Microsoft.EntityFrameworkCore;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;
using MovieTrackerProject.Persistence.Context;

namespace MovieTrackerProject.Persistence.Repositories
{
    public class RateRepository : IRateRepository<Rate>
    {
        private readonly AppDbContext _context;
        public RateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Rate entity)
        {
            _context.Set<Rate>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Rate entity)
        {
            _context.Set<Rate>().Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(Rate entity)
        {
            _context.Set<Rate>().Update(entity);
            await _context.SaveChangesAsync();
        }

        async Task<List<Rate>> IRateRepository<Rate>.GetAllAsync()
        {
            return await _context.Rates
            .Include(r => r.User) 
            .Include(r => r.Movie) 
            .ToListAsync(); 

        }

        public async Task<Rate> GetByIdAsync(int id)
        {
            return await _context.Rates
                .Include(r => r.User) 
                .Include(r => r.Movie) 
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
