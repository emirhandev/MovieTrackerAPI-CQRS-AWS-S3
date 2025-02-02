using MediatR;

namespace MovieTrackerProject.Application.Features.Movies.Queries.GetMovie
{
    public class GetMovieQuery : IRequest<List<GetMovieQueryResponse>>
    {
    }
}
