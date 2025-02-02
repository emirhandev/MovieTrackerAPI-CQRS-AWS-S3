using MediatR;


namespace MovieTrackerProject.Application.Features.Rates.Queries.GetRatesByIdWithRate
{
    public class GetRatesByIdWithRateQuery: IRequest<List<GetRatesByIdWithRateQueryResponse>>
    {
        public int Id { get; set; }

        public GetRatesByIdWithRateQuery(int id)
        {
            Id = id;
        }
    }
}
