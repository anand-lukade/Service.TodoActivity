using MediatR;
using Service.TodoActivity.Responses;
using System;
using System.Collections.Generic;
namespace Service.TodoActivity.Queries
{
    public class SearchTasksQuery : IRequest<List<TaskResponse>>
    {        
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public DateTime? DueDates { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Priority { get; set; }
        public SearchTasksQuery()
        {
        }
    }
}
