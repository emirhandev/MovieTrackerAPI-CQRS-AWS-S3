using MediatR;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Features.Rates.Queries.GetRates
{
    public class GetRatesQueryHandler:IRequestHandler<GetRatesQuery,List<GetRatesQueryResponse>>
    {
        private readonly IRateRepository<Rate> _rateRepository;

 
        public GetRatesQueryHandler(IRateRepository<Rate> rateRepository)
        {
            _rateRepository = rateRepository;
        }


        public async Task<List<GetRatesQueryResponse>> Handle(GetRatesQuery query,CancellationToken cancellationToken)
        {
        
            var rates = await _rateRepository.GetAllAsync();

          
            var response = rates.Select(r => new GetRatesQueryResponse
            {
                Id = r.Id,
                Rank = r.Rank,
                Comment = r.Comment,
                Username = r.User.Username, 
                MovieTitle = r.Movie.Title 
            }).ToList();

         
            return response;
        }
    }
}
