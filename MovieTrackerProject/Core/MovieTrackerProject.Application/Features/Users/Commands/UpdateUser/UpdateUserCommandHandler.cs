using MediatR;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler:IRequestHandler<UpdateUserCommand,Unit>
    {
        private readonly IRepository<User> _repository;

        public UpdateUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task <Unit> Handle(UpdateUserCommand command,CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(command.Id);
            if (user != null)  
            {
                user.Email = command.Email;
                user.Username = command.Username;
                await _repository.UpdateAsync(user);
            }
            else
            {
                throw new ArgumentException("User not found");  
            }
            return Unit.Value;
        }
    }
}
