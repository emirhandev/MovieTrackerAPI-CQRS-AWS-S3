using MediatR;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Features.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommandHandler :IRequestHandler<UpdateMovieCommand, Unit>
    {
        private readonly IRepository<Movie> _repository;

        public UpdateMovieCommandHandler(IRepository<Movie> repository)
        {
            _repository = repository;
        }
        public async Task <Unit> Handle(UpdateMovieCommand command,CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            values.Title = command.Title;
            values.Genre = command.Genre;
            values.ReleaseYear = command.ReleaseYear;
            await _repository.UpdateAsync(values);
            return Unit.Value;
        }



    }
}
