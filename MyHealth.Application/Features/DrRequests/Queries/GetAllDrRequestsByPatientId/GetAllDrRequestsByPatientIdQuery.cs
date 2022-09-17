using MediatR;

namespace MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsByPatientId;

public class GetAllDrRequestsByPatientIdQuery : IRequest<List<GetAllDrRequestsByPatientIdViewModel>>
{
    public Guid PatientId { get; set; }
}
