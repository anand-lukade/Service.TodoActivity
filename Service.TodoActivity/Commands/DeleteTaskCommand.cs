using MediatR;
using Service.TodoActivity.Responses;
using System;

namespace Service.TodoActivity.Commands
{
    public class DeleteTaskCommand : IRequest<DeleteTaskResponse>
    {
        public Guid Id { get; }

        public DeleteTaskCommand(Guid id)
        {
            Id = id;
        }
    }
}
