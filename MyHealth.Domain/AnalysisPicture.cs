namespace MyHealth.Domain;

public class AnalysisPicture
{
    public Guid AnalysisPictureId { get; set; }
    public Guid DiseaseId { get; set; }
    public string? FileName { get; set; }
    public string? Description { get; set; }
    public string? Base64data { get; set; }
    public string? ContentType { get; set; }
}
