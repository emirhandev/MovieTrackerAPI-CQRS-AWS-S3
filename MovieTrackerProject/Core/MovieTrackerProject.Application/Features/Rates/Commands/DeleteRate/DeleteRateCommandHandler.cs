using MediatR;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Features.Rates.Commands.DeleteRate
{
    public class DeleteRateCommandHandler:IRequestHandler<DeleteRateCommand,Unit>
    {
        private readonly IRateRepository<Rate> _rateRepository;

        public DeleteRateCommandHandler(IRateRepository<Rate> rateRepository)
        {
            _rateRepository = rateRepository;
        }
        public async Task <Unit> Handle(DeleteRateCommand command,CancellationToken cancellationToken)
        {
            var value = await _rateRepository.GetByIdAsync(command.Id);
            await _rateRepository.DeleteAsync(value);
            return Unit.Value;

        }



    }
}
