using MediatR;
using Service.TodoActivity.Responses;
using System;
using System.Collections.Generic;

namespace Service.TodoActivity.Queries
{
    public class GetTasksQuery : IRequest<List<TaskResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public GetTasksQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
    }
}
