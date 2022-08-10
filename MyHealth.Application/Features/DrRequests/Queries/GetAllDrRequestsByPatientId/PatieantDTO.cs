namespace MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsByPatientId;
public class PatieantDTO
{
    public Guid PatientId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

}