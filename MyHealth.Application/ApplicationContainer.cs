using System;
using System.Reflection;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace MyHealth.Application;

public static class ApplicationContainer
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}
