namespace MyHealth.Domain;

public class Disease
{
    public Guid Id { get; set; }
    public string? DrId { get; set; }
    public string? PatientId { get; set; }
    public string? Name { get; set; }
    public string? Discription { get; set; }
    public DateTime DiagnosisDate { get; set; }
    public virtual ICollection<Picture?>? AnalysisPictures { get; set; }
}