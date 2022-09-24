using Microsoft.AspNetCore.Identity;
using MyHealth.Domain;
using System.ComponentModel.DataAnnotations;

namespace MyHealth.Persistence.Identity;

public class ApplicationUser : IdentityUser
{
    [Required, MaxLength(100)]
    public string? FirstName { get; set; }

    [Required, MaxLength(100)]
    public string? LastName { get; set; }

    public virtual Picture? ProfilePicture { get; set; }
    public Gender Gender { get; set; }
}

public enum Gender
{
    Mail,
    Femail
}