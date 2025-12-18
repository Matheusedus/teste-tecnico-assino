using TaskManager.Application.Interfaces;

namespace TaskManager.Application.UseCases.CompleteTask;

public class CompleteTaskHandler
{
    private readonly ITaskRepository _repository;

    public CompleteTaskHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(Guid taskId)
    {
        var task = await _repository.GetByIdAsync(taskId);

        if (task is null)
            throw new InvalidOperationException("Task not found");

        task.Complete();

        await _repository.UpdateAsync(task);
    }
}
