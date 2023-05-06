using CqrsInDotNet.Entities;
using Microsoft.EntityFrameworkCore;

namespace CqrsInDotNet.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<TodoItem> Todos { get; set; } = default!;
}