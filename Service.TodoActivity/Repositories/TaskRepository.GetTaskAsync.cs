using Service.TodoActivity.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.TodoActivity.Repositories
{    
    public partial class TaskRepository
    {
        public Task<TaskDto> GetTaskAsync(Guid id)
        {
            var result = _toDos?.Count > 0 ? _toDos.FirstOrDefault(x => x.Id == id) : null;
            return Task.FromResult(result);
        }
    }
}
