namespace MyHealth.Domain;
public class DrRequest
{
    public Guid DrRequestId { get; set; }
    public Guid DrId { get; set; }
    public Guid PatientId { get; set; }
    public DateTime RequestTime { get; set; }
    public DrRequestStatus Status { get; set; }
}
