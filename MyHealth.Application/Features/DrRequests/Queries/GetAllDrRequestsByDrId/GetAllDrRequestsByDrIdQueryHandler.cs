using AutoMapper;
using MediatR;
using MyHealth.Application.Contracts;

namespace MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsByDrId;
public class GetAllDrRequestsByDrIdQueryHandler
    : IRequestHandler<GetAllDrRequestsByDrIdQuery, List<GetAllDrRequestsByDrIdViewModel>>
{
    private readonly IAsyncDrRequestRepository repository;
    private readonly IMapper mapper;

    public GetAllDrRequestsByDrIdQueryHandler(IAsyncDrRequestRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<List<GetAllDrRequestsByDrIdViewModel>> Handle(GetAllDrRequestsByDrIdQuery request, CancellationToken cancellationToken)
    {
        var allDiseasesByPatieantId = await repository.GetAllByDrIdAsync(request.DrId);
        return mapper.Map<List<GetAllDrRequestsByDrIdViewModel>>(allDiseasesByPatieantId);
    }
}
