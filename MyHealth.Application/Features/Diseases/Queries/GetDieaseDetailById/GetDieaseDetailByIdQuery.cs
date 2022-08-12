using MediatR;

namespace MyHealth.Application.Features.Diseases.Queries.GetDieaseDetailById;

public class GetDieaseDetailByIdQuery : IRequest<GetDieaseDetailByIdViewModel>
{
    public Guid DieaseId { get; set; }
}
