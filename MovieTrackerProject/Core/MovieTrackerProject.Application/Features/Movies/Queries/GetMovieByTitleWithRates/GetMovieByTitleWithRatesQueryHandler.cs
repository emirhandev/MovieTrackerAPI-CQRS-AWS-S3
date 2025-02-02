using MediatR;
using MovieTrackerProject.Application.Features.Movies.Queries.GetMovieByTitleWithRates;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Features.Movies.Queries.GetMovieByIdWithRates
{
    public class GetMovieByTitleWithRatesQueryHandler:IRequestHandler<GetMovieByTitleWithRatesQuery,List<GetMovieByTitleWithRatesQueryResponse>>
    {
        private readonly IMovieRepository<Movie> _movieRepository;

        public GetMovieByTitleWithRatesQueryHandler(IMovieRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<GetMovieByTitleWithRatesQueryResponse>> Handle(GetMovieByTitleWithRatesQuery request,CancellationToken cancellationToken)
        {
            var targetMovie = await _movieRepository.GetByTitleAsync(request.MovieTitle);

            if (targetMovie == null)
                return new List<GetMovieByTitleWithRatesQueryResponse>();

            var response = targetMovie.Rates.Select(rate => new GetMovieByTitleWithRatesQueryResponse
            {
                MovieTitle = targetMovie.Title,
                Username = rate.User?.Username ?? "Unknown",
                Comment = rate.Comment,
                Rank = rate.Rank
            }).ToList();

            return response;
        }
    }
}
