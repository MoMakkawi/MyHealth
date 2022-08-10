using MediatR;
using MyHealth.Domain;

namespace MyHealth.Application.Features.DrRequests.Commands.SendDrRequestToPatient
{
    public class CreateDrRequestCommand : IRequest<Guid>
    {
        public Guid DrId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime RequestTime { get; set; }
        public DrRequestStatus Status { get; set; }
    }
}
