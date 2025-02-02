using MediatR;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Features.Users.Commands.AddMovie
{
    public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, Unit>
    {
        private readonly IUserRepository<User> _userRepository;

        public AddMovieCommandHandler(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(AddMovieCommand command, CancellationToken cancellationToken)
        {
       
            if (string.IsNullOrEmpty(command.MovieTitle))
            {
                throw new ArgumentException("Movie title cannot be null or empty.");
            }
            await _userRepository.AddMovieAsync(command.UserId, command.MovieTitle);
            return Unit.Value;
        }
    }
}
