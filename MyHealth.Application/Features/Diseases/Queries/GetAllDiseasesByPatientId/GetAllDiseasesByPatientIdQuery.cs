using MediatR;

namespace MyHealth.Application.Features.Diseases.Queries.GetAllDiseasesByPatientId;

public class GetAllDiseasesByPatientIdQuery : IRequest<List<GetAllDiseasesByPatientIdViewModel>>
{
    public string? PatientId { get; set; }
}