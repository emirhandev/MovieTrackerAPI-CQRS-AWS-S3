using MediatR;
namespace MovieTrackerProject.Application.Features.Movies.Queries.GetMovieById
{
    public class GetMovieByIdQuery : IRequest<GetMovieByIdQueryResponse>
    {
        public int Id { get; set; }

        public GetMovieByIdQuery(int id)
        {
            Id = id;
        }
    }
}
