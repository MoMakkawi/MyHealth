using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace MyHealth.Application;

public static class ApplicationContainer
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}