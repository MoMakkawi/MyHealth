namespace MyHealth.Domain;

public class Disease
{
    public Guid Id { get; set; }
    public Guid DrId { get; set; }
    public Guid PatientId { get; set; }
    public string? Name { get; set; }
    public string? Discription { get; set; }
    public IEnumerable<Guid>? AnalysisPictureGuids { get; set; }
}
