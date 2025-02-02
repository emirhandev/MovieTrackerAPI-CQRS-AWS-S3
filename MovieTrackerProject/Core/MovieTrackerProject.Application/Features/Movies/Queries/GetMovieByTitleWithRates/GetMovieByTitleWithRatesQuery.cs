using MediatR;
using MovieTrackerProject.Application.Features.Movies.Queries.GetMovieByIdWithRates;

namespace MovieTrackerProject.Application.Features.Movies.Queries.GetMovieByTitleWithRates
{
    public class GetMovieByTitleWithRatesQuery : IRequest<List<GetMovieByTitleWithRatesQueryResponse>>
    {
        public string MovieTitle { get; set; }
        public GetMovieByTitleWithRatesQuery(string movieTitle)
        {
            MovieTitle = movieTitle;
        }

      
    }
}
