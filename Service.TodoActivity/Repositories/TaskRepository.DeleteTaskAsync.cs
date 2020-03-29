using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.TodoActivity.Repositories
{
    public partial class TaskRepository
    {
        public Task DeleteTaskAsync(Guid id)
        {
            var obj = _toDos?.Count > 0 ? _toDos.FirstOrDefault(x => x.Id == id) : null;
            if (obj != null)
            {
                _toDos.Remove(obj);
            }                
            return Task.CompletedTask;
        }
    }
}
