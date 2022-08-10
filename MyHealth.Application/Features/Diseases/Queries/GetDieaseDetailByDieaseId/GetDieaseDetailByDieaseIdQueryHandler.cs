using AutoMapper;

using MediatR;

using MyHealth.Application.Contracts;
using MyHealth.Domain;

namespace MyHealth.Application.Features.Diseases.Queries.GetDieaseDetailByDieaseId;

public class GetDieaseDetailByDieaseIdQueryHandler
    : IRequestHandler<GetDieaseDetailByDieaseIdQuery,GetDieaseDetailByDieaseIdViewModel>
{
    private readonly IAsyncDiseaseRepository repository;
    private readonly IMapper mapper;

    public GetDieaseDetailByDieaseIdQueryHandler(IAsyncDiseaseRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<GetDieaseDetailByDieaseIdViewModel> Handle(GetDieaseDetailByDieaseIdQuery request, CancellationToken cancellationToken)
    {
        var diseasesByPatieantId = await repository.GetByIdAsync(request.DieaseId);
        return mapper.Map<GetDieaseDetailByDieaseIdViewModel>(diseasesByPatieantId);
    }
}
