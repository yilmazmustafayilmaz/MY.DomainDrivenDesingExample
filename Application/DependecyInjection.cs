using Domain.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), typeof(Entity).Assembly);
        });
        return services;
    }
}
