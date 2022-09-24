using MediatR;

namespace MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsByDrId;

public class GetAllDrRequestsByDrIdQuery : IRequest<List<GetAllDrRequestsByDrIdViewModel>>
{
    public Guid DrId { get; set; }
}