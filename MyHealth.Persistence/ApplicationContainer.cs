using System;
using System.Reflection;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace MyHealth.Persistence;

public static class ApplicationContainer
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var CleanArchitecture = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}
