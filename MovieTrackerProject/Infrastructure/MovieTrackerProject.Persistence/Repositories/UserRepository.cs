using Microsoft.EntityFrameworkCore;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;
using MovieTrackerProject.Persistence.Context;

namespace MovieTrackerProject.Persistence.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddMovieAsync(int userId, string movieTitle)
        {
            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Title.ToLower() == movieTitle.ToLower());
            if (movie == null)
            {
                throw new InvalidOperationException($"Movie with title '{movieTitle}' not found.");
            }

            var user = await _context.Users.Include(u => u.Movies)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new InvalidOperationException($"User with ID {userId} not found.");
            }
            if (user.Movies.Any(m => m.Title == movie.Title))
            {
                throw new InvalidOperationException($"User already has the movie '{movieTitle}'.");
            }


            if (!user.Movies.Any(m => m.Id == movie.Id))
            {
                user.Movies.Add(movie);
                movie.UserId = userId;


                _context.Entry(user).State = EntityState.Modified;
                _context.Entry(movie).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
        }

        public async Task AddMovieTMDBAsync(int userId, Movie movieToAdd)
        {

            var user = await _context.Users.Include(u => u.Movies)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new InvalidOperationException($"User with ID {userId} not found.");
            }


            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Title == movieToAdd.Title);


            if (movie == null)
            {

                _context.Movies.Add(movieToAdd);
                movieToAdd.UserId = userId;
                user.Movies.Add(movieToAdd);


                _context.Entry(user).State = EntityState.Modified;

            }


            else if (!user.Movies.Any(m => m.Title == movie.Title))
            {
                user.Movies.Add(movie);
                movie.UserId = userId;

                _context.Entry(user).State = EntityState.Modified;
                _context.Entry(movie).State = EntityState.Modified;


            }

            else
            {
                throw new InvalidOperationException($"User already has the movie '{movieToAdd.Title}'.");
            }
            await _context.SaveChangesAsync();

        }

       

        public async Task<string> FindUsernameAsync(int userId)
        {
            var user = await _context.Set<User>().FindAsync(userId);


            return user?.Username ?? string.Empty;
        }

    }
}