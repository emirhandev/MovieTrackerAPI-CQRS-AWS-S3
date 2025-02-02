using MediatR;

namespace MovieTrackerProject.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand: IRequest<Unit>
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
