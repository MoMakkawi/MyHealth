using MyHealth.Domain.DTOs;
using MyHealth.Domain;

namespace MyHealth.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdViewModel
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public Picture? ProfilePicture { get; set; }
    public Gender Gender { get; set; }
}
