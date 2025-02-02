using System.Text.Json;
using System.Text.Json.Serialization;
using MediatR;
using MovieTrackerProject.Application.Features.Dtos;
using MovieTrackerProject.Application.Services;

namespace MovieTrackerProject.Application.Features.TMDB.Queries.GetMovieByTMDBAPI
{
    public class GetMovieByTMDBAPIQueryHandler : IRequestHandler<GetMovieByTMDBAPIQuery, List<GetMovieByTMDBAPIQueryResponse>>
    {
        private readonly TMDBService _tmdbService;
        private readonly JsonSerializerOptions _jsonOptions;

        public GetMovieByTMDBAPIQueryHandler(TMDBService tmdbService)
        {
            _tmdbService = tmdbService;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
        }

        public async Task<List<GetMovieByTMDBAPIQueryResponse>> Handle(GetMovieByTMDBAPIQuery request, CancellationToken cancellationToken)
        {
            var content = await _tmdbService.SearchMoviesAsync(request.Title);

            try
            {
                var movieResult = JsonSerializer.Deserialize<TMDBDto>(content, _jsonOptions);

                if (movieResult == null || movieResult.Results == null)
                {
                    Console.WriteLine("Deserialization resulted in null");
                    return new List<GetMovieByTMDBAPIQueryResponse>();
                }

                return movieResult.Results.Select(movie => new GetMovieByTMDBAPIQueryResponse
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Overview = movie.Overview,
                    release_date = movie.ReleaseDate,
                    VoteAverage = movie.VoteAverage,
                }).ToList();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON Deserialization Error: {ex.Message}");
                Console.WriteLine($"Raw Content: {content}");
                throw;
            }
        }
    }
}
