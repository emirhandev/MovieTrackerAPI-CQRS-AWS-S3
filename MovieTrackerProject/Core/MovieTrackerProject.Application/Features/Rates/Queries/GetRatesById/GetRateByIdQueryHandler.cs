using MediatR;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Features.Rates.Queries.GetRatesById
{
    public class GetRateByIdQueryHandler:IRequestHandler<GetRateByIdQuery,GetRateByIdQueryResponse>
    {
        private readonly IRateRepository<Rate> _rateRepository;

        public GetRateByIdQueryHandler(IRateRepository<Rate> rateRepository)
        {
            _rateRepository = rateRepository;
        }

        public async Task<GetRateByIdQueryResponse> Handle(GetRateByIdQuery query,CancellationToken cancellationToken)
        {
        
            var rate = await _rateRepository.GetByIdAsync(query.Id);

            if (rate == null)
            {
                throw new Exception("Rate not found");
            }

            return new GetRateByIdQueryResponse
            {
                Id = rate.Id,
                Rank = rate.Rank,
                Comment = rate.Comment,
                Username = rate.User.Username,
                MovieTitle = rate.Movie.Title 
            };

        }
    }
}
