using MyHealth.Domain;

namespace MyHealth.Application.Contracts;

public interface IAsyncDrRequestRepository : IAsyncRepository<DrRequest>
{
    Task<List<DrRequest>> GetAllByDrIdAsync(Guid drId);
    Task<List<DrRequest>> GetAllByPatientIdAsync(Guid patieantId);

}
