using MovieTrackerProject.Application.Features.Dtos;


namespace MovieTrackerProject.Application.Features.Users.Queries.GetUserWithMovies
{
    public class GetUserWithMoviesResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<MovieDto> Movies { get; set; } = new List<MovieDto>();
    }
}
