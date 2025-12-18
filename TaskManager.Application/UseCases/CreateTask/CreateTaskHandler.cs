using TaskManager.Application.Interfaces;
using DomainTask = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.UseCases.CreateTask;

public class CreateTaskHandler
{
    private readonly ITaskRepository _repository;

    public CreateTaskHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> HandleAsync(CreateTaskCommand command)
    {
        var task = new DomainTask(
        command.Title,
        command.SlaInHours,
        command.FileName
        );

        await _repository.AddAsync(task);

        return task.Id;
    }
}
