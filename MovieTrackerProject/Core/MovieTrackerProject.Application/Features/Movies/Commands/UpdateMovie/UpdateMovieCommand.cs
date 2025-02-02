using MediatR;

namespace MovieTrackerProject.Application.Features.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
    }
}
