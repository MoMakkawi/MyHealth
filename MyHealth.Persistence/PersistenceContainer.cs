using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MyHealth.Application.Contracts;
using MyHealth.Persistence.Repositories;

namespace MyHealth.Persistence;

public static class PersistenceContainer
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services ,IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("MyHealthContext") ?? throw new InvalidOperationException("Connection string 'MyHealthAPIContext' not found.")));


        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

        services.AddScoped(typeof(IAsyncDiseaseRepository), typeof(DiseaseRepository));
        services.AddScoped(typeof(IAsyncDrRequestRepository), typeof(DrRequestRepository));
        services.AddScoped(typeof(IAsyncAnalysisPictureRepository), typeof(AnalysisPictureRepository));

        return services;
    }
}
