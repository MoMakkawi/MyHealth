using MediatR;

namespace MyHealth.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public Guid userId;
}
