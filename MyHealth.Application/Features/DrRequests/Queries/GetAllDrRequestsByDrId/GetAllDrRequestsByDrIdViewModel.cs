using MyHealth.Application.DTOs;
using MyHealth.Domain;

namespace MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsByDrId;
public class GetAllDrRequestsByDrIdViewModel
{
    public DoctorDTO? Doctor { get; set; }
    public DateTime RequestTime { get; set; }
    public DrRequestStatus Status { get; set; }
}
