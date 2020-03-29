using Service.TodoActivity.Dtos;
using System.Threading.Tasks;

namespace Service.TodoActivity.Repositories
{
    public partial class TaskRepository
    {
        public Task<TaskDto> CreateTaskAsync(TaskDto toDoDto)
        {
            _toDos.Add(toDoDto);
            return Task.FromResult(toDoDto);
        }
    }
}
