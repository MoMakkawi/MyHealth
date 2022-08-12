namespace MyHealth.Application.Features.Diseases.Queries.GetDieaseDetailById;

public class DoctorDTO
{
    public Guid DrId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}