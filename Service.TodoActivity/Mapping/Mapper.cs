using Service.TodoActivity.Commands;
using Service.TodoActivity.Dtos;
using Service.TodoActivity.Queries;
using Service.TodoActivity.Repositories;
using Service.TodoActivity.Responses;
using System;
using System.Collections.Generic;

namespace Service.TodoActivity.Mapping
{
    public class Mapper: IMapper
    {
        private readonly ITaskRepository _taskRepository;

        public Mapper(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public TaskDto MapCreateTaskCommandToTaskDto(CreateTaskCommand command)
        {
            return new TaskDto()
            {                
                Id=Guid.NewGuid(),
                DueDates = command.DueDate,
                CreatedDate = DateTime.Now,
                Priority = command.Priority,
                Title = command.Title
            };
        }

        public TaskResponse MapTaskDtosToTaskResponses(TaskDto dtos)
        {
            return new TaskResponse()
            {
                Id = dtos.Id,
                DueDates = dtos.DueDates,
                CreatedDate=dtos.CreatedDate,
                Priority = dtos.Priority,
                Title = dtos.Title
            };
        }
        public List<TaskResponse> MapTaskDtosToTaskResponses(List<TaskDto> dtos)
        {
            List<TaskResponse> result = new List<TaskResponse>();
            foreach (var dto in dtos)
            {
                result.Add(new TaskResponse()
                {
                    Id = dto.Id,
                    DueDates = dto.DueDates,
                    CreatedDate = dto.CreatedDate,
                    Priority = dto.Priority,
                    Title = dto.Title
                });
            }
            return result;
        }

        public TaskSearchDTO MapSearchTasksQueryToTaskSearchDTO(SearchTasksQuery taskSearch)
        {
            return new TaskSearchDTO()
            {
                Id=taskSearch.Id,
                Title = taskSearch.Title,
                DueDates = taskSearch.DueDates,
                Priority = taskSearch.Priority
            };
        }
    }
}
