using DomainTask = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Interfaces;

public interface ITaskRepository
{
    Task AddAsync(DomainTask task);
    Task<IReadOnlyList<DomainTask>> GetAllAsync();
    Task<DomainTask?> GetByIdAsync(Guid id);
    Task UpdateAsync(DomainTask task);
}
