using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MyHealth.Application.Contracts;
using MyHealth.Persistence.Repositories;

namespace MyHealth.Persistence;

public static class PersistenceContainer
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        //, IConfiguration conf

        //services.AddDbContext<ApplicationDbContext>(options =>
        //options.UseSqlServer(conf.GetConnectionString("ConnectionString")));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

        services.AddScoped<IAsyncDiseaseRepository, DiseaseRepository>();
        services.AddScoped<IAsyncDrRequestRepository, DrRequestRepository>();

        return services;
    }
}
