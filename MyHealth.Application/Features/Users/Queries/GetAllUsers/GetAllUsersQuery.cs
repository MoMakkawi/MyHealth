using MediatR;

namespace MyHealth.Application.Features.Users.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<List<GetAllUsersViewModel>>
{

}
