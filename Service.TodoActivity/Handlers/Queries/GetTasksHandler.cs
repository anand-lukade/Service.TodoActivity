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
    public class GetTasksHandler : IRequestHandler<GetTasksQuery, List<TaskResponse>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetTasksHandler> _logger;
        public GetTasksHandler(ILogger<GetTasksHandler> logger, ITaskRepository taskRepository, IMapper mapper)
        {
            _logger = logger;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<List<TaskResponse>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {            
            var tasks = await _taskRepository.GetTasksAsync(request.Page,request.Size);
            if(tasks==null)
            {
                throw new ApplicationException($"no record found");
            }
            _logger.LogInformation($"Requested tasks count : {tasks?.Count}");
            return _mapper.MapTaskDtosToTaskResponses(tasks);
        }
    }
}
