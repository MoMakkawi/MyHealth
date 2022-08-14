using MyHealth.Domain;

namespace MyHealth.Application.Contracts;

public interface IAsyncAnalysisPictureRepository 
{
    Task<List<AnalysisPicture>> GetAnalysisPictures(Guid diseaseId);
    Task DeleteAllAnalysisPicturesByDiseaseId(Guid diseaseId);
    Task AddAnalysisPictures(IEnumerable<AnalysisPicture> analysisPictures);
    Task UpdateAnalysisPictures(IEnumerable<AnalysisPicture>? analysisPictures);
}
