using MediatR;
using Microsoft.Extensions.Logging;
using Service.TodoActivity.Commands;
using Service.TodoActivity.Mapping;
using Service.TodoActivity.Repositories;
using Service.TodoActivity.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Service.TodoActivity.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, DeleteTaskResponse>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteTaskHandler> _logger;
        public DeleteTaskHandler(ILogger<DeleteTaskHandler> logger, ITaskRepository taskRepository, IMapper mapper)
        {
            _logger = logger;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<DeleteTaskResponse> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {            
             await _taskRepository.DeleteTaskAsync(request.Id);
            _logger.LogInformation($"Deleted task : {request.Id}");
            return new DeleteTaskResponse()
            {
                UserMessage = "Task deleted successfully"
            };
        }
    }
}
