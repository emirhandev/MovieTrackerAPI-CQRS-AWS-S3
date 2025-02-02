using MediatR;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Features.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Unit>
    {
        private readonly IRepository<Movie> _repository;

        public CreateMovieCommandHandler(IRepository<Movie> repository)
        {
            _repository = repository;
        }

        public async Task <Unit> Handle(CreateMovieCommand command, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Movie
            {
                Title = command.Title,
                Genre = command.Genre,
                ReleaseYear = command.ReleaseYear,
            });
            return Unit.Value;
        }




    }
}
