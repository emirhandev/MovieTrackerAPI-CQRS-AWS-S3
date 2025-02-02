using Microsoft.AspNetCore.Mvc;
using MovieTrackerProject.Application.Features.Users.Commands.AddMovie;
using MovieTrackerProject.Application.Features.Users.Commands.CreateUser;
using MovieTrackerProject.Application.Features.Users.Commands.DeleteUser;
using MovieTrackerProject.Application.Features.Users.Commands.UpdateUser;
using MovieTrackerProject.Application.Features.Users.Queries.GetUser;
using MovieTrackerProject.Application.Features.Users.Queries.GetUserById;
using MovieTrackerProject.Application.Features.Users.Queries.GetUserWithMovies;
using MovieTrackerProject.Application.Features.Rates.Queries.GetRatesByIdWithRate;
using MediatR;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;

    }
    [HttpGet("Get-All-User")]
    public async Task<IActionResult> UserList()
    {
        var values = await _mediator.Send(new GetUserQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var query = new GetUserByIdQuery(id);
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("Get-Users-With-Watchlist")]
    public async Task<IActionResult> GetUserWithMovies()
    {
        var values = await _mediator.Send(new GetUserWithMoviesQuery());
        return Ok(values);
    }

    [HttpPost("Create-User")]
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        await _mediator.Send(command);
        return Ok("User created successfully!");
    }

    [HttpDelete("Delete-User")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _mediator.Send(new DeleteUserCommand(id));
        return Ok("User deleted successfully!");
    }

    [HttpPut("Update-User")]
    public async Task<IActionResult> UpdateUser([FromQuery] int id, [FromBody] UpdateUserCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return Ok("User Updated");
    }

    [HttpPost("Add-Movie-To-Watchlist")]
    public async Task<IActionResult> AddMovie([FromBody] AddMovieCommand command)
    {
        await _mediator.Send(command);
        return Ok("Movie added successfully!");
    }

    [HttpGet("Get-User-By-Id-WithRates/{id}")]
    public async Task<IActionResult> GetUserByIdWithRates(int id)
    {
        var values = await _mediator.Send(new GetRatesByIdWithRateQuery(id));
        return Ok(values);
    }

}