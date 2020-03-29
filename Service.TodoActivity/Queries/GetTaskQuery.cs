using MediatR;
using Service.TodoActivity.Responses;
using System;

namespace Service.TodoActivity.Queries
{
    public class GetTaskQuery : IRequest<TaskResponse>
    {
        public Guid Id { get; }

        public GetTaskQuery(Guid id)
        {
            Id = id;
        }
    }
}
