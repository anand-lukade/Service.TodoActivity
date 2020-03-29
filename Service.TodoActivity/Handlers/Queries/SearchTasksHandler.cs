using MediatR;
using Microsoft.Extensions.Logging;
using Service.TodoActivity.Mapping;
using Service.TodoActivity.Queries;
using Service.TodoActivity.Repositories;
using Service.TodoActivity.Responses;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Service.TodoActivity.Handlers
{
    public class SearchTasksHandler : IRequestHandler<SearchTasksQuery, List<TaskResponse>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetTaskByIdHandler> _logger;
        public SearchTasksHandler(ILogger<GetTaskByIdHandler> logger, ITaskRepository taskRepository, IMapper mapper)
        {
            _logger = logger;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<List<TaskResponse>> Handle(SearchTasksQuery request, CancellationToken cancellationToken)
        {
            var input = _mapper.MapSearchTasksQueryToTaskSearchDTO(request);
            var tasks = await _taskRepository.SearchTasksAsync(input);            
            _logger.LogInformation($"Requested task counts : {tasks?.Count}");
            return _mapper.MapTaskDtosToTaskResponses(tasks);
        }
    }
}
