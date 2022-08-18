using Microsoft.EntityFrameworkCore;

using MyHealth.Application.Contracts;
using MyHealth.Domain;

namespace MyHealth.Persistence.Repositories
{
    public class DrRequestRepository : BaseRepository<DrRequest>, IAsyncDrRequestRepository
    {
        public DrRequestRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }

        public async Task<List<DrRequest>> GetAllByDrIdAsync(string drId)
        {
            return await _dbContext.DrRequests.Where(r => r.DrId == drId).ToListAsync();
        }

        public async Task<List<DrRequest>> GetAllByPatieantIdAsync(string patieantId)
        {
            return await _dbContext.DrRequests.Where(r => r.PatientId == patieantId).ToListAsync();
        }
    }
}
