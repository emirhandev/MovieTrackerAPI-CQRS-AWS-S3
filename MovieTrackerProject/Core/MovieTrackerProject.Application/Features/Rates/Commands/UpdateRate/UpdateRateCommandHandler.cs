using MediatR;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Features.Rates.Commands.UpdateRate
{
    public class UpdateRateCommandHandler:IRequestHandler<UpdateRateCommand,Unit>
    {
        private readonly IRateRepository<Rate> _rateRepository;

        public UpdateRateCommandHandler(IRateRepository<Rate> rateRepository)
        {
            _rateRepository = rateRepository;
        }
        public async Task <Unit> Handle(UpdateRateCommand command,CancellationToken cancellationToken)
        {
            var values = await _rateRepository.GetByIdAsync(command.Id);
            values.Rank = command.Rank;
            values.Comment = command.Comment;
            values.MovieId = command.MovieId;
            await _rateRepository.UpdateAsync(values);
            return Unit.Value;

        }

        }
}
