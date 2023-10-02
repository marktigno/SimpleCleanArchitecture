using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleCleanArchitecture.Application.Persistence;
using SimpleCleanArchitecture.Infrastructure.Persistence;

namespace SimpleCleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<PersistenceDbContext>(options => options.UseInMemoryDatabase(databaseName: "TodoItemDb"));
        services.AddScoped<ITodoItemRepository, TodoItemRepository>();
        
        return services;
    }
}