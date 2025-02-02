using MediatR;

namespace MovieTrackerProject.Application.Features.Movies.Queries.GetMovieByTitle
{
    public class GetMovieByTitleQuery:IRequest<GetMovieByTitleQueryResponse>
    {
        public GetMovieByTitleQuery(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
    }
}
