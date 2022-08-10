using MyHealth.Domain;

namespace MyHealth.Application.Contracts;

public interface IAsyncDiseaseRepository : IAsyncRepository<Disease> 
{
    Task<List<Disease>> GetAllByPatieantIdAsync(Guid patieantId);
}
