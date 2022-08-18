using MyHealth.Domain;

namespace MyHealth.Application.Contracts;

public interface IAsyncDrRequestRepository : IAsyncRepository<DrRequest>
{
    Task<List<DrRequest>> GetAllByDrIdAsync(string drId);
    Task<List<DrRequest>> GetAllByPatieantIdAsync(string patieantId);

}
