using AutoMapper;

using MediatR;

using MyHealth.Application.Contracts;
using MyHealth.Domain.DTOs;

namespace MyHealth.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IAsyncUserRepository userRepository;
    private readonly IMapper mapper;

    public UpdateUserCommandHandler(IAsyncUserRepository userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var appUserDTO = mapper.Map<ApplicationUserDTO>(request);
        await userRepository.UpdateAsync(appUserDTO);

        return Unit.Value;
    }
}