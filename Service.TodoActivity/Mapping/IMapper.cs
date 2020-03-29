using Service.TodoActivity.Commands;
using Service.TodoActivity.Dtos;
using Service.TodoActivity.Queries;
using Service.TodoActivity.Responses;
using System.Collections.Generic;

namespace Service.TodoActivity.Mapping
{
    public interface IMapper
    {
        TaskResponse MapTaskDtosToTaskResponses(TaskDto dtos);
        List<TaskResponse> MapTaskDtosToTaskResponses(List<TaskDto> dtos);
        TaskDto MapCreateTaskCommandToTaskDto(CreateTaskCommand command);
        TaskSearchDTO MapSearchTasksQueryToTaskSearchDTO(SearchTasksQuery taskSearch);
    }
}
