using MediatR;

namespace MyHealth.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<GetUserByIdViewModel>
{
    public Guid UserId { get; set; }
}