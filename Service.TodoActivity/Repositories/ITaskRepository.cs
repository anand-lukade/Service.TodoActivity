using Service.TodoActivity.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.TodoActivity.Repositories
{
    public interface ITaskRepository
    {
        Task<TaskDto> GetTaskAsync(Guid id);
        Task<List<TaskDto>> GetTasksAsync(int page, int size);
        Task<TaskDto> CreateTaskAsync(TaskDto toDoDto);
        Task<List<TaskDto>> SearchTasksAsync(TaskSearchDTO searchCriteria);
        Task DeleteTaskAsync(Guid id);
    }
}
