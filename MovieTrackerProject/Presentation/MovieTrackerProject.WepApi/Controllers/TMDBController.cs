using Microsoft.AspNetCore.Mvc;
using MediatR;
using MovieTrackerProject.Application.Features.TMDB.Queries.GetMovieByTMDBAPI;
using MovieTrackerProject.Application.Features.TMDB.Commands.AddMovieToWatchListByIdWithTMDB;

namespace MovieTrackerProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TMDBController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TMDBController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("search/{title}")]
        public async Task<IActionResult> SearchMovies(string title)
        {
            var query = new GetMovieByTMDBAPIQuery(title);
            var movies = await _mediator.Send(query);
            return Ok(movies);
        }

        [HttpPost("Add-Movie-to-Watchlist")]
        public async Task<IActionResult> AddMovieTMDB(AddMovieToWatchListByIdWithTMDBCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { Message = "Movie added To Watchlist successfully" });
        }
    }
}
