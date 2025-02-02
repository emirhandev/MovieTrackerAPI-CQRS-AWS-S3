using MediatR;

namespace MovieTrackerProject.Application.Features.Rates.Queries.GetRatesById
{
    public class GetRateByIdQuery:IRequest<GetRateByIdQueryResponse>
    {
        public int Id { get; set; }

        public GetRateByIdQuery(int id)
        {
            Id = id;
        }
    }
}
