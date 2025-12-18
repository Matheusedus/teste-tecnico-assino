namespace TaskManager.Application.UseCases.CreateTask;

public class CreateTaskCommand
{
    public string Title { get; init; } = string.Empty;
    public int SlaInHours { get; init; }
    public string? FileName { get; init; }
}
