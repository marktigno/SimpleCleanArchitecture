using Microsoft.Extensions.DependencyInjection;
using SimpleCleanArchitecture.Application.Services;

namespace SimpleCleanArchitecture.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ITodoItemService, TodoItemService>();
        return services;
    }
}