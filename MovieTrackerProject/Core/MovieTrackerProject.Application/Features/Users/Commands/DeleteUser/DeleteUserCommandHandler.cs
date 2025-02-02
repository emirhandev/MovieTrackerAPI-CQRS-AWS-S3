using MediatR;

using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IRepository<User> _repository;

        public DeleteUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task <Unit> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
            return Unit.Value;
        }
    }
}
