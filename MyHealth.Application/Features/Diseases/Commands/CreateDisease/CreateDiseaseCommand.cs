using MediatR;

using MyHealth.Domain;

namespace MyHealth.Application.Features.Diseases.Commands.CreateDisease;

public class CreateDiseaseCommand : IRequest<Guid>
{
    public Guid DrId { get; set; }
    public Guid PatientId { get; set; }
    public string? Name { get; set; }
    public string? Discription { get; set; }
    public DateTime DiagnosisDate => DateTime.Now;
    public ICollection<Picture?>? AnalysisPictures { get; set; }
}
