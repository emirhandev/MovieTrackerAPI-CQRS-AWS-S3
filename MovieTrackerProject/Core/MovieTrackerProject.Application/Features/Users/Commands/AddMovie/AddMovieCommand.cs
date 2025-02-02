using MediatR;

namespace MovieTrackerProject.Application.Features.Users.Commands.AddMovie
{
    public class AddMovieCommand: IRequest<Unit>
    {
        public int UserId { get; set; }
        public string MovieTitle { get; set; }
        

        public AddMovieCommand(string movieTitle, int userId)
        {
            UserId = userId;
            MovieTitle = movieTitle;
            
        }
    }
}

