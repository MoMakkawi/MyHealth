
using System.ComponentModel.DataAnnotations;

namespace MyHealth.Domain.DTOs;

public class ApplicationUserDTO
{
    public Guid Id { get; set; }
    [Required, MaxLength(100)]
    public string? UserName { get; set; }
    [Required, MaxLength(100)]
    public string? FirstName { get; set; }
    [Required, MaxLength(100)]
    public string? LastName { get; set; }
    [Required, Phone]
    public string? PhoneNumber { get; set; }
    [Required, EmailAddress]
    public string? Email { get; set; } 
    [Required,DataType(DataType.Password)]
    public string? Password { get; set; }
    [Required,DataType(DataType.Password)]
    public string? PasswordConfirm { get; set; }
    public Picture? ProfilePicture { get; set; }
    [Required]
    public Gender Gender { get; set; }
}
public enum Gender
{
    Mail,
    Femail
}