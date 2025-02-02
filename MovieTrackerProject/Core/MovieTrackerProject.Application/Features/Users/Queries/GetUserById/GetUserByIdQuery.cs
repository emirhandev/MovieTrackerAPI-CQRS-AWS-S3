﻿using MediatR;

namespace MovieTrackerProject.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<GetUserByIdQueryResponse>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
