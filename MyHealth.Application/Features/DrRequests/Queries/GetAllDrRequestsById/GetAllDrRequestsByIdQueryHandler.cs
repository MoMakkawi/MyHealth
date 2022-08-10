using AutoMapper;
using MediatR;
using MyHealth.Application.Contracts;
using MyHealth.Domain;

namespace MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsById;

public class GetAllDrRequestsByIdQueryHandler
    : IRequestHandler<GetAllDrRequestsByIdQuery, IEnumerable<GetAllDrRequestsByIdViewModel>>
{
    private readonly IAsyncRepository<Disease> repository;
    private readonly IMapper mapper;

    public GetAllDrRequestsByIdQueryHandler(IAsyncRepository<Disease> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<GetAllDrRequestsByIdViewModel>> Handle(GetAllDrRequestsByIdQuery request, CancellationToken cancellationToken)
    {
        var allDiseasesByPatieantId = await repository.GetAllByIdAsync(request.UserId);
        return mapper.Map<IEnumerable<GetAllDrRequestsByIdViewModel>>(allDiseasesByPatieantId);
    }
}
