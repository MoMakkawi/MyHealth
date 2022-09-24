using AutoMapper;

using MediatR;

using MyHealth.Application.Contracts;

namespace MyHealth.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler
        : IRequestHandler<GetAllUsersQuery, List<GetAllUsersViewModel>>
    {
        private readonly IAsyncUserRepository userRepository;
        private readonly IMapper mapper;

        public GetAllUsersQueryHandler(IAsyncUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<List<GetAllUsersViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var userDTOs = await userRepository.GetAllApplicationUsersDTOs();

            return mapper.Map<List<GetAllUsersViewModel>>(userDTOs);
        }
    }
}