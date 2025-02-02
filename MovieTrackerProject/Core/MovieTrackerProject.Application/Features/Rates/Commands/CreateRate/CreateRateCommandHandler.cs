using MediatR;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Features.Rates.Commands.CreateRate
{
    public class CreateRateCommandHandler:IRequestHandler<CreateRateCommand,Unit>
    {
        private readonly IRateRepository<Rate> _rateRepository;

        public CreateRateCommandHandler(IRateRepository<Rate> rateRepository)
        {
            _rateRepository = rateRepository;
        }

        public async Task<Unit> Handle(CreateRateCommand command,CancellationToken cancellationToken)
        {
            await _rateRepository.CreateAsync(new Rate
            {
                Comment = command.Comment,
                MovieId = command.MovieId,
                Rank = command.Rank,
                UserId = command.UserId,

            });
            return Unit.Value;
        }
    }
}
