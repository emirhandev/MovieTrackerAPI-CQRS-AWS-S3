using Microsoft.EntityFrameworkCore;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;
using MovieTrackerProject.Persistence.Context;

namespace MovieTrackerProject.Persistence.Repositories
{
    public class MovieRepository : IMovieRepository<Movie>
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movies
             .Include(r => r.User)
             .Include(r => r.Rates)
             .ToListAsync();
        }

        public async Task<Movie> GetByTitleAsync(string title)
        {
            return await _context.Movies
                .Include(m => m.Rates) 
                .ThenInclude(r => r.User) 
                .FirstOrDefaultAsync(x => x.Title.ToLower() == title.ToLower());
        }

    }
}
