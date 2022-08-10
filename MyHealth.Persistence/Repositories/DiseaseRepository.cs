using Microsoft.EntityFrameworkCore;

using MyHealth.Application.Contracts;
using MyHealth.Domain;

namespace MyHealth.Persistence.Repositories;


public class DiseaseRepository : BaseRepository<Disease>, IAsyncDiseaseRepository
{
    public DiseaseRepository(ApplicationDbContext dbContext) 
        : base(dbContext)
    {
    }

    public async Task<List<Disease>> GetAllByPatieantIdAsync(Guid patieantId)
    {
        return await _dbContext.Diseases.Where(d => d.PatientId == patieantId).ToListAsync();
    }
}
