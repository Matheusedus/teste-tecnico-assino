using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities;

public class Task
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public TaskState Status { get; private set; }
    public int SlaInHours { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime ExpiresAt { get; private set; }
    public string? FileName { get; private set; }

    protected Task() { }

    public Task(string title, int slaInHours, string? fileName = null)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required");

        if (slaInHours <= 0)
            throw new ArgumentException("SLA must be greater than zero");

        Id = Guid.NewGuid();
        Title = title;
        SlaInHours = slaInHours;
        CreatedAt = DateTime.UtcNow;
        ExpiresAt = CreatedAt.AddHours(slaInHours);
        Status = TaskState.Pending;
        FileName = fileName;
    }

    public void Complete()
    {
        if (Status == TaskState.Expired)
            throw new InvalidOperationException("Cannot complete an expired task");

        Status = TaskState.Completed;
    }

    public void Expire()
    {
        if (Status == TaskState.Completed)
            return;

        Status = TaskState.Expired;
    }

    public bool IsExpired(DateTime now)
    {
        return Status == TaskState.Pending && now > ExpiresAt;
    }
}