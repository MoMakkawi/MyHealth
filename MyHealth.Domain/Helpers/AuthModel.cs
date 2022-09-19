namespace MyHealth.Domain.Helpers;

public class AuthModel
{
    public Guid UserId { get; set; }
    public string? Message { get; set; }
    public string? UserName { get; set; }
    public bool IsAuthenticated { get; set; }
    public string? Email { get; set; }
    public string? Role { get; set; }
    public string? Token { get; set; }
    public DateTime ExpiresOn { get; set; }
}
