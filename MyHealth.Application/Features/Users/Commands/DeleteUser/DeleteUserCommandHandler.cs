using MediatR;

using MyHealth.Application.Contracts;

namespace MyHealth.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IAsyncUserRepository userRepository;

    public DeleteUserCommandHandler(IAsyncUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await userRepository.DeleteAsync(request.userId);

        return Unit.Value;
    }
}