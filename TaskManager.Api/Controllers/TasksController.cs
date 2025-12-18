using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Interfaces;
using TaskManager.Application.UseCases.CreateTask;
using TaskManager.Application.UseCases.ListTasks;

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
    public async Task<IActionResult> Create([FromBody] CreateTaskCommand command)
    {
        var handler = new CreateTaskHandler(_repository);
        var taskId = await handler.HandleAsync(command);

        return CreatedAtAction(nameof(GetAll), new { id = taskId }, new { id = taskId });
    }

    /// <summary>
    /// List tasks
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] bool completed = false)
    {
        var handler = new ListTasksHandler(_repository);
        var tasks = await handler.HandleAsync(completed);

        return Ok(tasks);
    }
}
