using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Interfaces
{
    public interface ITMDBService
    {
        Task<Movie> FindMovieByTitleAsync(string title);
    }
}
