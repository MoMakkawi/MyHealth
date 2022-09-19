using MediatR;

using MyHealth.Domain;
using MyHealth.Domain.DTOs;

namespace MyHealth.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public Picture? ProfilePicture { get; set; }
    public Gender Gender { get; set; }
    public string? Role { get; set; }
}
