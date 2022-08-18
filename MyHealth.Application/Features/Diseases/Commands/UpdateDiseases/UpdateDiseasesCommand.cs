using MediatR;

using MyHealth.Domain;

namespace MyHealth.Application.Features.Diseases.Commands.UpdateDiseases;

public class UpdateDiseasesCommand : IRequest
{
    public Guid DrId { get; set; }
    public Guid PatientId { get; set; }
    public string? Name { get; set; }
    public string? Discription { get; set; }
    public ICollection<Picture>? AnalysisPictures { get; set; }
}
