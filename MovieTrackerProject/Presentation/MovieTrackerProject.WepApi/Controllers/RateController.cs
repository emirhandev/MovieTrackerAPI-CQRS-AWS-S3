using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTrackerProject.Application.Features.Rates.Commands.CreateRate;
using MovieTrackerProject.Application.Features.Rates.Commands.DeleteRate;
using MovieTrackerProject.Application.Features.Rates.Commands.UpdateRate;
using MovieTrackerProject.Application.Features.Rates.Queries.GetRates;
using MovieTrackerProject.Application.Features.Rates.Queries.GetRatesById;


namespace MovieTrackerProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RateController(IMediator mediator)
        {
            _mediator = mediator;
          
        }

        [HttpGet("Get-AllRates")]
        public async Task<IActionResult> RateList()
        {
            var values = await _mediator.Send(new GetRatesQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRateById(int id)
        {
            var value = await _mediator.Send(new GetRateByIdQuery(id));
            return Ok(value);
        }


        [HttpPost("Create-Rate")]
        public async Task<IActionResult> CreateRate(CreateRateCommand command)
        {
            await _mediator.Send(command);
            return Ok("Rate Added");
        }

        [HttpPut("Update-Rate")]
        public async Task<IActionResult> UpdateRate(UpdateRateCommand command)
        {
            await _mediator.Send(command);
            return Ok("Rate Updated");
        }

        [HttpDelete("Delete-Rate")]
        public async Task<IActionResult> DeleteRate(int id)
        {
            await _mediator.Send(new DeleteRateCommand(id));
            return Ok("Rate Deleted");
        }



    }
}
