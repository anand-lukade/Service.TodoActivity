using MediatR;
using Service.TodoActivity.Responses;
using System;

namespace Service.TodoActivity.Commands
{
    public class CreateTaskCommand : IRequest<TaskResponse>
    {        
        public string Title { get; set; }
        public DateTime DueDate { get; set; }        
        public int Priority { get; set; }
    }
}
