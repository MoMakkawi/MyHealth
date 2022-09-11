using AutoMapper;

using MediatR;

using MyHealth.Application.Contracts;
using MyHealth.Domain.DTOs;

namespace MyHealth.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IAsyncUserRepository userRepository;
    private readonly IMapper mapper;
    public CreateUserCommandHandler(IAsyncUserRepository userRepository , IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var appUserDTO = mapper.Map<ApplicationUserDTO>(request);
        var user = await userRepository.AddAsync(appUserDTO);

        return user.Id;
    }
}
