
using System.ComponentModel.DataAnnotations;

using MediatR;

using MyHealth.Domain;
using MyHealth.Domain.DTOs;

namespace MyHealth.Application.Features.Users.Commands.CreateUser;
public class CreateUserCommand : IRequest<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public Picture? ProfilePicture { get; set; }
    public Gender Gender { get; set; }
}