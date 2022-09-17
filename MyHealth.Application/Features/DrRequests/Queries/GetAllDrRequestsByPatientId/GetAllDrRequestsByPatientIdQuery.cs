using MediatR;

namespace MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsByPatientId;

public class GetAllDrRequestsByPatientIdQuery : IRequest<IEnumerable<GetAllDrRequestsByPatientIdViewModel>>
{
    public Guid PatientId { get; set; }
}
