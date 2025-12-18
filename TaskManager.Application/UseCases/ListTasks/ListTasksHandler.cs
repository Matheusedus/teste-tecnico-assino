using TaskManager.Application.Interfaces;
using DomainTask = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.UseCases.ListTasks;

public class ListTasksHandler
{
    private readonly ITaskRepository _repository;

    public ListTasksHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<DomainTask>> HandleAsync(
    bool onlyCompleted = false,
    bool onlyExpired = false)
    {
        var tasks = await _repository.GetAllAsync();

        if (onlyCompleted)
            tasks = tasks
                .Where(t => t.Status == Domain.Enums.TaskState.Completed)
                .ToList();

        if (onlyExpired)
            tasks = tasks
                .Where(t => t.Status == Domain.Enums.TaskState.Expired)
                .ToList();

        return tasks;
    }
}
