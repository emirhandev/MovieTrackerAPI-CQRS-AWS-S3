using MediatR;

namespace MovieTrackerProject.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand:IRequest<Unit>
    {
        public UpdateUserCommand(string username, string email)
        {
            Username = username;
            Email = email;
        }

        public int Id { get; set; }  
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
