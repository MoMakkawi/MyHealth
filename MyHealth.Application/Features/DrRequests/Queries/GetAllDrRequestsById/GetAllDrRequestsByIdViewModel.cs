using MyHealth.Domain;

namespace MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsById;

public class GetAllDrRequestsByIdViewModel
{
    public UserDTO? User { get; set; }
    public DateTime RequestTime { get; set; }
    public DrRequestStatus Status { get; set; }
}
