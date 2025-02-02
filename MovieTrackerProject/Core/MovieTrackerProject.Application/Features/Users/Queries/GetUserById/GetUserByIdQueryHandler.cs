using MediatR;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResponse>
    {
        private readonly IRepository<User> _repository;

        public GetUserByIdQueryHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);

            if (user == null)
            {
                return null; 
            }

            return new GetUserByIdQueryResponse
            {
                Email = user.Email,
                Id = user.Id,
                Username = user.Username,
            };
        }
    }
}