using Microsoft.EntityFrameworkCore;

using MyHealth.Application.Contracts;
using MyHealth.Domain;

namespace MyHealth.Persistence.Repositories;

public class AnalysisPictureRepository : IAsyncAnalysisPictureRepository
{
    protected readonly ApplicationDbContext _dbContext;

    public AnalysisPictureRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<List<AnalysisPicture>> GetAnalysisPictures(Guid diseaseId)
        => await _dbContext.AnalysisPictures.Where(pic => pic.DiseaseId == diseaseId).ToListAsync();
    public async Task DeleteAllAnalysisPicturesByDiseaseId(Guid diseaseId)
    {
         _dbContext.AnalysisPictures
            .Where(pic => pic.DiseaseId == diseaseId)
            .ToList()
            .ForEach(pic => _dbContext.AnalysisPictures.Remove(pic));
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddAnalysisPictures(IEnumerable<AnalysisPicture> analysisPictures)
    {
        await _dbContext.AnalysisPictures.AddRangeAsync(analysisPictures);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAnalysisPictures(IEnumerable<AnalysisPicture>? analysisPictures)
    {
        _dbContext.AnalysisPictures.UpdateRange(analysisPictures);
        await _dbContext.SaveChangesAsync();
    }
}
