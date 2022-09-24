namespace MyHealth.Domain;

public class Picture
{
    public Guid PictureId { get; set; }
    public string? FileName { get; set; }
    public string? Description { get; set; }
    public string? Base64data { get; set; }
    public string? ContentType { get; set; }
}