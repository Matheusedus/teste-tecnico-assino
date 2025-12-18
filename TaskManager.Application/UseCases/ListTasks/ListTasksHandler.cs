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

    public async Task<IReadOnlyList<DomainTask>> HandleAsync(bool onlyCompleted = false)
    {
        var tasks = await _repository.GetAllAsync();

        if (onlyCompleted)
            return tasks
                .Where(t => t.Status == Domain.Enums.TaskState.Completed)
                .ToList();

        return tasks;
    }
}
