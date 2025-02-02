using MediatR;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Features.Movies.Queries.GetMovie
{
    public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, List<GetMovieQueryResponse>>
    {
        private readonly IRepository<Movie> _repository;

        public GetMovieQueryHandler(IRepository<Movie> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetMovieQueryResponse>> Handle(GetMovieQuery request,CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetMovieQueryResponse
            {
                Id = x.Id,
                Title = x.Title,
                Genre = x.Genre,
                ReleaseYear = x.ReleaseYear,
            }).ToList();


        }

    }
}
