using MediatR;

namespace MyHealth.Application.Features.Diseases.Queries.GetDieaseDetailByDieaseId;

public class GetDieaseDetailByDieaseIdQuery : IRequest<GetDieaseDetailByDieaseIdViewModel>
{
    public Guid? DieaseId { get; set; }
}