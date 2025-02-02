using MediatR;
using MovieTrackerProject.Application.Features.Movies.Queries.GetMovieByTitle;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;

public class GetMovieByTitleQueryHandler:IRequestHandler<GetMovieByTitleQuery,GetMovieByTitleQueryResponse>
{
    private readonly IMovieRepository<Movie> _movieRepository;

    public GetMovieByTitleQueryHandler(IMovieRepository<Movie> movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<GetMovieByTitleQueryResponse> Handle(GetMovieByTitleQuery request,CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetByTitleAsync(request.Title);

        if (movie == null)
        {
            return null;  
        }

        return new GetMovieByTitleQueryResponse
        {
            Id = movie.Id,
            Title = movie.Title,
            Genre = movie.Genre,
            ReleaseYear = movie.ReleaseYear
        };
    }
}
