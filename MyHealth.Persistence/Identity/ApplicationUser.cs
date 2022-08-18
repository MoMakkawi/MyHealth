
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

using MyHealth.Domain;

namespace MyHealth.Persistence.Identity;

public class ApplicationUser : IdentityUser
{

    [Required, MaxLength(100)]
    public string? FirstName { get; set; }
    [Required, MaxLength(100)]
    public string? LastName { get; set; }
    public Picture? ProfilePicture { get; set; }
    public Gender Gender { get; set; }
}
public enum Gender
{
    Mail,
    Femail
}

