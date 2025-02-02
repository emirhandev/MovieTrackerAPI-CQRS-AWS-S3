
namespace MovieTrackerProject.Application.Interfaces
{
    public interface IMovieRepository<Movie>
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie> GetByTitleAsync(string title);
    }
}
