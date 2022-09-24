using AutoMapper;
using MediatR;

using MyHealth.Application.Contracts;

namespace MyHealth.Application.Features.Users.Queries.GetUserById
{
    public class GetUserbyIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdViewModel>
    {
        private readonly IAsyncUserRepository userRepository;
        private readonly IMapper mapper;

        public GetUserbyIdQueryHandler(IAsyncUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<GetUserByIdViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(request.UserId);
            return mapper.Map<GetUserByIdViewModel>(user);
        }
    }
}