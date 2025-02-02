using MediatR;

namespace MovieTrackerProject.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand: IRequest<Unit>
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
