using MediatR;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Features.Movies.Queries.GetMovieById
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, GetMovieByIdQueryResponse>
    {
        private readonly IRepository<Movie> _repository;

        public GetMovieByIdQueryHandler(IRepository<Movie> repository)
        {
            _repository = repository;
        }

        public async Task<GetMovieByIdQueryResponse> Handle(GetMovieByIdQuery request,CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);

            return new GetMovieByIdQueryResponse
            {
                Id = values.Id,
                Title = values.Title,
                Genre = values.Genre,
                ReleaseYear = values.ReleaseYear,


            };


        }

    }
}
