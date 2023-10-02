using Microsoft.EntityFrameworkCore;
using SimpleCleanArchitecture.Domain.Entities;

namespace SimpleCleanArchitecture.Infrastructure;

public class PersistenceDbContext : DbContext
{
    public PersistenceDbContext(DbContextOptions<PersistenceDbContext> options) : base(options)
    {
    }
    
    public DbSet<TodoItem> TodoItems { get; set;}
}