using System;

namespace Service.TodoActivity.Dtos
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDates { get; set; }
        public DateTime CreatedDate { get; set; } = new DateTime();
        public int Priority { get; set; }
    }
}
