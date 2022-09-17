using MyHealth.Domain;
using MyHealth.Domain.DTOs;

namespace MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsByPatientId;
public class GetAllDrRequestsByPatientIdViewModel
{
    public UserPersonalInfoDTO? Patient { get; set; }
    public DateTime RequestTime { get; set; }
    public DrRequestStatus Status { get; set; }
}
