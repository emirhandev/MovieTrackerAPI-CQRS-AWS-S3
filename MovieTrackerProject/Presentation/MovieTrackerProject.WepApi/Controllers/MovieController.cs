using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTrackerProject.Application.Features.Movies.Commands.CreateMovie;
using MovieTrackerProject.Application.Features.Movies.Commands.DeleteMovie;
using MovieTrackerProject.Application.Features.Movies.Commands.UpdateMovie;
using MovieTrackerProject.Application.Features.Movies.Queries.GetMovie;
using MovieTrackerProject.Application.Features.Movies.Queries.GetMovieById;
using MovieTrackerProject.Application.Features.Movies.Queries.GetMovieByTitle;
using MovieTrackerProject.Application.Features.Movies.Queries.GetMovieByTitleWithRates;


namespace MovieTrackerProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Get-All-Movies")]
        public async Task<IActionResult> MovieList()
        {
            var values = await _mediator.Send(new GetMovieQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var value = await _mediator.Send(new GetMovieByIdQuery(id));
            return Ok(value);
        }

        [HttpGet("title/{title}")]
        public async Task<IActionResult> GetMovieByTitle(string title)
        {
            var movie = await _mediator.Send(new GetMovieByTitleQuery(title));
            if (movie == null)
            {
                return NotFound("Movie not found");
            }
            return Ok(movie);
        }

        [HttpGet("Get-Movies-With-Rates/{title}")]
        public async Task<IActionResult> GetMoviesByTitleWithRates(string title)
        {
            var movie = await _mediator.Send(new GetMovieByTitleWithRatesQuery(title));
            if (movie == null)
            {
                return NotFound("Movie not found");
            }
            return Ok(movie);
        }

        [HttpPost("Create-Movie")]
        public async Task<IActionResult> CreateMovie(CreateMovieCommand command)
        {
            await _mediator.Send(command);
            return Ok("Movie Added");
        }

        [HttpDelete("Delete-Movie")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _mediator.Send(new  DeleteMovieCommand(id));
            return Ok("Movie Deleted");
        }

        [HttpPut("Update-Movie")]
        public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
        {
            await _mediator.Send(command);
            return Ok("Movie Updated");
        }

    }
}
