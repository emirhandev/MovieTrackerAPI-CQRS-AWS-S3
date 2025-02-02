using MediatR;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Features.Movies.Commands.DeleteMovie
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, Unit>
    {
        private readonly IRepository<Movie> _repository;

        public DeleteMovieCommandHandler(IRepository<Movie> repository)
        {
            _repository = repository;
        }

        public async  Task<Unit> Handle(DeleteMovieCommand command,CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
            return Unit.Value;


        }




    }
}
