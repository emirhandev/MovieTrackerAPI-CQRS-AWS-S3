using MediatR;

namespace MovieTrackerProject.Application.Features.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<List<GetUserQueryResponse>>
    {
    }
}
