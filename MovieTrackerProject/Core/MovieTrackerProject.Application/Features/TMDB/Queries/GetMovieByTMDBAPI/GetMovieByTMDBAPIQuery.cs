using MediatR;

namespace MovieTrackerProject.Application.Features.TMDB.Queries.GetMovieByTMDBAPI
{
    public class GetMovieByTMDBAPIQuery : IRequest<List<GetMovieByTMDBAPIQueryResponse>>
    {
        public string Title { get; set; }

        public GetMovieByTMDBAPIQuery(string title)
        {
            Title = title;
        }
    }
}
