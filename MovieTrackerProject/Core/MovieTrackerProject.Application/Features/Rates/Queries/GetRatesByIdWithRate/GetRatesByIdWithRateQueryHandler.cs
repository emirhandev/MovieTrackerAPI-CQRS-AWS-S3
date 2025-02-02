using MediatR;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Features.Rates.Queries.GetRatesByIdWithRate
{
    public class GetRatesByIdWithRateQueryHandler : IRequestHandler<GetRatesByIdWithRateQuery, List<GetRatesByIdWithRateQueryResponse>>
    {
        private readonly IRateRepository<Rate> _rateRepository;

        public GetRatesByIdWithRateQueryHandler(IRateRepository<Rate> rateRepository)
        {
            _rateRepository = rateRepository;
        }

        public async Task<List<GetRatesByIdWithRateQueryResponse>> Handle(GetRatesByIdWithRateQuery query, CancellationToken cancellationToken)
        {
            var rates = await _rateRepository.GetAllAsync();

            var response = rates
                .Where(r => r.UserId == query.Id)  
                .Select(r => new GetRatesByIdWithRateQueryResponse
                {
                    Id = r.Id,
                    MovieTitle = r.Movie != null ? r.Movie.Title : "N/A", 
                    Rank = r.Rank,
                    Comment = r.Comment
                })
                .ToList();

            return response;
        }
    }
}
