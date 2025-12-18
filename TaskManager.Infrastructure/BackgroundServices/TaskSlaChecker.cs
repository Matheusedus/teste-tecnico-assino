using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Interfaces;

namespace TaskManager.Infrastructure.BackgroundServices;

public class TaskSlaChecker : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public TaskSlaChecker(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<ITaskRepository>();

            var tasks = await repository.GetAllAsync();
            var now = DateTime.UtcNow;

            foreach (var task in tasks)
            {
                if (task.IsExpired(now))
                {
                    task.Expire();
                    await repository.UpdateAsync(task);
                }
            }

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
