using AutoMapper;

using MediatR;

using MyHealth.Application.Contracts;
using MyHealth.Domain;

namespace MyHealth.Application.Features.Diseases.Queries.GetDieaseDetailById;

public class GetDieaseDetailByIdQueryHandler
    : IRequestHandler<GetDieaseDetailByIdQuery,GetDieaseDetailByIdViewModel>
{
    private readonly IAsyncRepository<Disease> repository;
    private readonly IMapper mapper;

    public GetDieaseDetailByIdQueryHandler(IAsyncRepository<Disease> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<GetDieaseDetailByIdViewModel> Handle(GetDieaseDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var diseasesByPatieantId = await repository.GetByIdAsync(request.DieaseId);
        return mapper.Map<GetDieaseDetailByIdViewModel>(diseasesByPatieantId);
    }
}
