using MediatR;

namespace MovieTrackerProject.Application.Features.Rates.Commands.UpdateRate
{
    public class UpdateRateCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public int Rank { get; set; }
        public string Comment { get; set; }
        public int? MovieId { get; set; }

    }
}
