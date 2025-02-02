using MediatR;

namespace MovieTrackerProject.Application.Features.Movies.Commands.CreateMovie
{
    public class CreateMovieCommand : IRequest<Unit>
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
    }
}
