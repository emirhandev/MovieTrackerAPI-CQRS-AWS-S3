using MediatR;
using MovieTrackerProject.Application.Features.Dtos;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Features.Users.Queries.GetUserWithMovies
{
    public class GetUserWithMoviesResponseHandler : IRequestHandler<GetUserWithMoviesQuery, List<GetUserWithMoviesResponse>>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Movie> _movieRepository;

        public GetUserWithMoviesResponseHandler(IRepository<User> userRepository, IRepository<Movie> movieRepository)
        {
            _userRepository = userRepository;
            _movieRepository = movieRepository;
        }

        public async Task<List<GetUserWithMoviesResponse>> Handle(GetUserWithMoviesQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            var movies = await _movieRepository.GetAllAsync();
             
            var response = users.Select(user => new GetUserWithMoviesResponse
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Movies = movies.Where(m => m.UserId == user.Id)
                .Select(movie => new MovieDto
                 {
                 Id = movie.Id,
                 Title = movie.Title,
                 Genre = movie.Genre,
                 ReleaseYear = movie.ReleaseYear
                 }).ToList()
            }).ToList();

            return response;
        }
    }
}