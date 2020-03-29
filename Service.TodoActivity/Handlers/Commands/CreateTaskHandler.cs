using MediatR;
using Microsoft.Extensions.Logging;
using Service.TodoActivity.Commands;
using Service.TodoActivity.Mapping;
using Service.TodoActivity.Repositories;
using Service.TodoActivity.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Service.TodoActivity.Handlers
{
    public class CreateTaskHandler:IRequestHandler<CreateTaskCommand, TaskResponse>
    {
        private readonly ITaskRepository _toDoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTaskHandler> _logger;

        public CreateTaskHandler(ILogger<CreateTaskHandler> logger, ITaskRepository toDoRepository, IMapper mapper)
        {
            _logger = logger;
            _toDoRepository = toDoRepository;
            _mapper = mapper;
        }

        public async Task<TaskResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var req = _mapper.MapCreateTaskCommandToTaskDto(request);
            var task = await _toDoRepository.CreateTaskAsync(req);
            _logger.LogInformation($"Created new task : {task.Title} with Due Date: {task.DueDates}");
            return _mapper.MapTaskDtosToTaskResponses(task);
        }
    }
}
