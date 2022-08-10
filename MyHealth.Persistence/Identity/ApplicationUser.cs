
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

namespace MyHealth.Persistence.Identity;

public class ApplicationUser : IdentityUser
{
    [Required, MaxLength(100)]
    public string? FirstName { get; set; }

    [Required, MaxLength(100)]
    public string? LastName { get; set; }

    public string? ProfilePicture { get; set; }

}
