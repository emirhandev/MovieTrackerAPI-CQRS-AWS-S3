using MediatR;


namespace MovieTrackerProject.Application.Features.Users.Queries.GetUserWithMovies
{
    public class GetUserWithMoviesQuery : IRequest<List<GetUserWithMoviesResponse>>
    {
    }
}
