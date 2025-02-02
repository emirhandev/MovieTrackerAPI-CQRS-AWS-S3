using MediatR;

namespace MovieTrackerProject.Application.Features.Rates.Commands.DeleteRate
{
    public class DeleteRateCommand:IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteRateCommand(int id)
        {
            Id = id;
        }

    }
}
