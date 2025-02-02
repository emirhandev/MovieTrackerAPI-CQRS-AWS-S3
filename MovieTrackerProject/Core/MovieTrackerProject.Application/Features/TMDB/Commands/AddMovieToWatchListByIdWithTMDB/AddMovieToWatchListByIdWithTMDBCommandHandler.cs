using System.Text.Json;
using MediatR;
using MovieTrackerProject.Application.Features.Dtos;
using MovieTrackerProject.Application.Features.TMDB.Commands.AddMovieToWatchListByIdWithTMDB;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Application.Services;
using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Features.Users.Commands.AddMovie
{
    public class AddMovieToWatchListByIdWithTMDBCommandHandler : IRequestHandler<AddMovieToWatchListByIdWithTMDBCommand, Unit>
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly TMDBService _tmdbService;
        private readonly JsonSerializerOptions _jsonOptions;

        public AddMovieToWatchListByIdWithTMDBCommandHandler(IUserRepository<User> userRepository, TMDBService tmdbService, JsonSerializerOptions jsonOptions)
        {
            _userRepository = userRepository;
            _tmdbService = tmdbService;
            _jsonOptions = jsonOptions;
        }

        public async Task<Unit> Handle(AddMovieToWatchListByIdWithTMDBCommand command, CancellationToken cancellationToken)
        {
          
            var content = await _tmdbService.GetMovieByIdAsync(command.MovieId);

            try
            {

                var movieResult = JsonSerializer.Deserialize<TMDBDto.MovieApiResult>(content, _jsonOptions);

                if (movieResult == null)
                {
                    Console.WriteLine("Deserialization resulted in null");
                    return Unit.Value;
                }

                var genre = movieResult.GenreIds != null && movieResult.GenreIds.Any()
                    ? string.Join(",", movieResult.GenreIds)
                    : "N/A";


                var movieToAdd = new Movie
                {
                    Title = movieResult.Title,
                    Genre = genre,
                    ReleaseYear = int.Parse(movieResult.ReleaseDate.Substring(0, 4))


                };

                await _userRepository.AddMovieTMDBAsync(command.UserId, movieToAdd);

            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON Deserialization Error: {ex.Message}");
                Console.WriteLine($"Raw Content: {content}");
                throw;
            }
            return Unit.Value;
        }

    }
}