using Service.TodoActivity.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.TodoActivity.Repositories
{
    public partial class TaskRepository
    {
        public Task<List<TaskDto>> SearchTasksAsync(TaskSearchDTO searchCriteria)
        {
            if(_toDos==null)
            {
                return Task.FromResult(_toDos);
            }
            IEnumerable<TaskDto> result = _toDos;

            if (searchCriteria.Id != null)
            {
                result = _toDos.Where(x => x.Id == searchCriteria.Id);
            }
            if (searchCriteria.Title != null)
            {
                result = _toDos.Where(x => x.Title == searchCriteria.Title);
            }
            if (searchCriteria.CreatedDate != null)
            {
                result = _toDos.Where(x => x.CreatedDate == searchCriteria.CreatedDate.Value);
            }
            if (searchCriteria.Priority != 0)
            {
                result = _toDos.Where(x => x.Priority == searchCriteria.Priority);
            }
            if (searchCriteria.DueDates != null)
            {
                result = _toDos.Where(x => x.DueDates == searchCriteria.DueDates.Value);
            }

            return Task.FromResult(result?.ToList());
        }
    }
}
