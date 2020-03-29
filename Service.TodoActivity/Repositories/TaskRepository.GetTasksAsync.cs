using Service.TodoActivity.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.TodoActivity.Repositories
{
    public partial class TaskRepository
    {
        public Task<List<TaskDto>> GetTasksAsync(int page,int size)
        {
            var result = _toDos.Take(size).Skip((page-1) * size);
            return Task.FromResult(_toDos);
        }
    }
}
