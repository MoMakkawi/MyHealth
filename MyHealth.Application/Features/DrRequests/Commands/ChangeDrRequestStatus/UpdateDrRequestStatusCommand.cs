using MediatR;

using MyHealth.Domain;

namespace MyHealth.Application.Features.DrRequests.Commands.ChangeDrRequestStatus;

public class UpdateDrRequestStatusCommand : IRequest
{
    public Guid Id { get; set; }
    public DrRequestStatus Status { get; set; }
}