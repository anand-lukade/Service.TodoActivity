using System;

namespace Service.TodoActivity.Responses
{
    public class TaskResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDates { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Priority { get; set; }
    }
}
