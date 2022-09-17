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

        public async Task<List<DrRequest>> GetAllByDrIdAsync(Guid drId)
        {
            return await _dbContext.DrRequests
                .Where(r => r.DrId == drId.ToString())
                .ToListAsync();
        }

        public async Task<List<DrRequest>> GetAllByPatientIdAsync(Guid patientId)
        {
            return await _dbContext.DrRequests
                .Where(r => r.PatientId == patientId.ToString())
                .ToListAsync();
        }
    }
}
