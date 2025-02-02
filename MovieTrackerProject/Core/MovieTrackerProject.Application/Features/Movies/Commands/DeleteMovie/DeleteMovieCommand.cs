using MediatR;

namespace MovieTrackerProject.Application.Features.Movies.Commands.DeleteMovie
{
    public class DeleteMovieCommand: IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteMovieCommand(int id)
        {
            Id = id;
        }
    }
}
