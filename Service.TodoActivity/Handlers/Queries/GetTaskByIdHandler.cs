using MediatR;
using Microsoft.Extensions.Logging;
using Service.TodoActivity.Mapping;
using Service.TodoActivity.Queries;
using Service.TodoActivity.Repositories;
using Service.TodoActivity.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Service.TodoActivity.Handlers
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskQuery, TaskResponse>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetTaskByIdHandler> _logger;
        public GetTaskByIdHandler(ILogger<GetTaskByIdHandler> logger, ITaskRepository taskRepository, IMapper mapper)
        {
            _logger = logger;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<TaskResponse> Handle(GetTaskQuery request, CancellationToken cancellationToken)
        {            
            var task = await _taskRepository.GetTaskAsync(request.Id);
            if(task==null)
            {
                throw new ApplicationException($"Provided id {request.Id} not found");
            }
            _logger.LogInformation($"Requested task : {task.Title} with Created Date: {task.DueDates}");
            return _mapper.MapTaskDtosToTaskResponses(task);
        }
    }
}
