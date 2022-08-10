using MediatR;

namespace MyHealth.Application.Features.Diseases.Queries.GetAllDiseasesByPatientId;

public class GetAllDiseasesByPatientIdQuery : IRequest<IEnumerable<GetAllDiseasesByPatientIdViewModel>>
{
    public Guid PatientId { get; set; }
}
