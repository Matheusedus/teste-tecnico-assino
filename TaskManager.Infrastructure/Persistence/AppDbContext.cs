using Microsoft.EntityFrameworkCore;
using DomainTask = TaskManager.Domain.Entities.Task;

namespace TaskManager.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<DomainTask> Tasks => Set<DomainTask>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
