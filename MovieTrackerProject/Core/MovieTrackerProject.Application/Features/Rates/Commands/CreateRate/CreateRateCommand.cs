using MediatR;
namespace MovieTrackerProject.Application.Features.Rates.Commands.CreateRate
{
    public class CreateRateCommand: IRequest<Unit>
    {
   
        public int Rank { get; set; }
        public string Comment { get; set; }
        public int? UserId { get; set; }
        public int? MovieId { get; set; }
      


    }
}
