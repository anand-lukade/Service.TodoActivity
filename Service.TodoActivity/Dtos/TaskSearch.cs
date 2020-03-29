using System;

namespace Service.TodoActivity.Dtos
{
    public class TaskSearchDTO
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public DateTime? DueDates { get; set; }
        public DateTime? CreatedDate { get; } = new DateTime();
        public int? Priority { get; set; }
    }
}
