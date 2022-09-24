namespace MyHealth.Domain;

public class DrRequest
{
    public Guid Id { get; set; }
    public string? DrId { get; set; }
    public string? PatientId { get; set; }
    public DateTime RequestTime { get; set; }
    public DrRequestStatus Status { get; set; }
}