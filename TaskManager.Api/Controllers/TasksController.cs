using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Interfaces;
using TaskManager.Application.UseCases.CreateTask;
using TaskManager.Application.UseCases.ListTasks;
using TaskManager.Application.UseCases.CompleteTask;


namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _repository;

    public TasksController(ITaskRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Create a new task
    /// </summary>
    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Create(
    [FromForm] string title,
    [FromForm] int slaInHours,
    [FromForm] IFormFile? file)
    {
        string? fileName = null;

        if (file is not null)
        {
            var uploadsPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Uploads"
            );

            if (!Directory.Exists(uploadsPath))
                Directory.CreateDirectory(uploadsPath);

            fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(uploadsPath, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
        }

        var command = new CreateTaskCommand
        {
            Title = title,
            SlaInHours = slaInHours,
            FileName = fileName
        };

        var handler = new CreateTaskHandler(_repository);
        var taskId = await handler.HandleAsync(command);

        return Ok(new { id = taskId });
    }

    /// <summary>
    /// List tasks
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll(
    [FromQuery] bool completed = false,
    [FromQuery] bool expired = false)
    {
        var handler = new ListTasksHandler(_repository);
        var tasks = await handler.HandleAsync(completed, expired);

        return Ok(tasks);
    }

    /// <summary>
    /// Complete a task
    /// </summary>
    [HttpPut("{id}/complete")]
    public async Task<IActionResult> Complete(Guid id)
    {
        var handler = new CompleteTaskHandler(_repository);
        await handler.HandleAsync(id);

        return NoContent();
    }
}
