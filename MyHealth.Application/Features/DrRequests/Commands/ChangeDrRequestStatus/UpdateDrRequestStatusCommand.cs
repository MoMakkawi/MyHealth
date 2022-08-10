using MediatR;

using MyHealth.Domain;

namespace MyHealth.Application.Features.DrRequests.Commands.ChangeDrRequestStatus;

public class UpdateDrRequestStatusCommand : IRequest
{
    public Guid DrRequestId { get; set; }
    public Guid DrId { get; set; }
    public Guid PatientId { get; set; }
    public DateTime RequestTime { get; set; }
    public DrRequestStatus Status { get; set; }
}
