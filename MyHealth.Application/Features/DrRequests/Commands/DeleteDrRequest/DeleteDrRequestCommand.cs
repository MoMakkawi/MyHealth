using MediatR;

namespace MyHealth.Application.Features.DrRequests.Commands.DeleteDrRequest;

public class DeleteDrRequestCommand : IRequest
{
    public Guid DrRequestId { get; set; }
}
