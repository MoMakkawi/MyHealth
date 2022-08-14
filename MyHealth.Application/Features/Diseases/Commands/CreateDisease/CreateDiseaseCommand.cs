using MediatR;

using MyHealth.Domain;

namespace MyHealth.Application.Features.Diseases.Commands.CreateDisease;

public class CreateDiseaseCommand : IRequest<Guid>
{
    public Guid DrId { get; set; }
    public Guid PatientId { get; set; }
    public string? Name { get; set; }
    public string? Discription { get; set; }
    public IEnumerable<AnalysisPicture>? AnalysisPictures { get; set; }
}
