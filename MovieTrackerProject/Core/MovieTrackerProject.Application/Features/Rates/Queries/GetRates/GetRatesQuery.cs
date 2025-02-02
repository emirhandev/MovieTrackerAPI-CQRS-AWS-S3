using MediatR;

namespace MovieTrackerProject.Application.Features.Rates.Queries.GetRates
{
    public class GetRatesQuery:IRequest<List<GetRatesQueryResponse>>
    {
    }
}
