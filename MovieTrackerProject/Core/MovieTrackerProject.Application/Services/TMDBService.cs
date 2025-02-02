using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace MovieTrackerProject.Application.Services
{
    public class TMDBService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly string _apiKey;

        public TMDBService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

            // Load configuration from appsettings.json
            _baseUrl = configuration["TMDB:BaseUrl"] ?? throw new ArgumentNullException("TMDB:BaseUrl");
            _apiKey = configuration["TMDB:ApiKey"] ?? throw new ArgumentNullException("TMDB:ApiKey");

            _httpClient.BaseAddress = new Uri(_baseUrl);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }

        public async Task<string> SearchMoviesAsync(string query)
        {
            var response = await _httpClient.GetAsync($"search/movie?query={Uri.EscapeDataString(query)}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Raw API Response (Search): {content}");
            return content;
        }

        public async Task<string> GetMovieByIdAsync(int movieId)
        {
            var response = await _httpClient.GetAsync($"movie/{movieId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Raw API Response (GetById): {content}");
            return content;
        }
    }
}
