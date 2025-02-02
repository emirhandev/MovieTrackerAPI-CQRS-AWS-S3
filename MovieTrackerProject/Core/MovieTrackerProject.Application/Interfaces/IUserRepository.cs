using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Interfaces
{
    public interface IUserRepository<User>
    {
        Task AddMovieAsync(int userId, string movieTitle);

        Task AddMovieTMDBAsync(int userId, Movie addMovieToAdd);
        Task<string> FindUsernameAsync(int userId);

    }
}
