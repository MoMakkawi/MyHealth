using MyHealth.Domain;

namespace MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsByPatientId;
public class GetAllDrRequestsByPatientIdViewModel
{
    public PatieantDTO? Patieant { get; set; }
    public DateTime RequestTime { get; set; }
    public DrRequestStatus Status { get; set; }
}
