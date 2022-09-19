using AutoMapper;

using MediatR;

using MyHealth.Application.Contracts;
using MyHealth.Domain.DTOs;
using MyHealth.Domain.Helpers;

namespace MyHealth.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand, AuthModel>
{
    private readonly IAsyncUserRepository userRepository;
    private readonly IMapper mapper;
    public CreateUserCommandHandler(IAsyncUserRepository userRepository , IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<AuthModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var appUserDTO = mapper.Map<ApplicationUserDTO>(request);
        return await userRepository.AddAsync(appUserDTO);
    }
}
