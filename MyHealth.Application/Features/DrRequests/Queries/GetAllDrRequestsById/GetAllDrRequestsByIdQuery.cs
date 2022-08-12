using MediatR;

namespace MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsById;

public class GetAllDrRequestsByIdQuery : IRequest<IEnumerable<GetAllDrRequestsByIdViewModel>>
{
    //this UserId can be Id of Dr/Patient 
    public Guid UserId { get; set; }
}
