using MediatR;

namespace MovieTrackerProject.Application.Features.TMDB.Commands.AddMovieToWatchListByIdWithTMDB
{
    public class AddMovieToWatchListByIdWithTMDBCommand : IRequest<Unit>
    {
        public AddMovieToWatchListByIdWithTMDBCommand(int userId, int movieId)
        {
            UserId = userId;
            MovieId = movieId;
        }

        public int UserId { get;  }
        public int MovieId { get; }
    }
}