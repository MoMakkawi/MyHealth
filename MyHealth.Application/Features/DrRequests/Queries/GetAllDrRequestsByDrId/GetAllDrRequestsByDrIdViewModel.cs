using MyHealth.Domain;
using MyHealth.Domain.DTOs;

namespace MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsByDrId;

public class GetAllDrRequestsByDrIdViewModel
{
    public UserPersonalInfoDTO? Doctor { get; set; }
    public DateTime RequestTime { get; set; }
    public DrRequestStatus Status { get; set; }
}