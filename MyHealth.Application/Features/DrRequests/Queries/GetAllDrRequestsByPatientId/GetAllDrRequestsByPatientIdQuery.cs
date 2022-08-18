using MediatR;

namespace MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsByPatientId;

public class GetAllDrRequestsByPatientIdQuery : IRequest<IEnumerable<GetAllDrRequestsByPatientIdViewModel>>
{
    public string PatientId { get; set; }
}
