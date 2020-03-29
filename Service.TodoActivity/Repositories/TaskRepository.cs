using Service.TodoActivity.Dtos;
using System.Collections.Generic;

namespace Service.TodoActivity.Repositories
{
    public partial class TaskRepository:ITaskRepository
    {
        private readonly static List<TaskDto> _toDos;
        static TaskRepository()
        {
            _toDos = new List<TaskDto>();
        }
    }
}
