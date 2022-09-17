using AutoMapper;
using MediatR;
using MyHealth.Application.Contracts;
using MyHealth.Domain;

namespace MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsByPatientId;

public class GetAllDrRequestsByPatientIdQueryHandler
    : IRequestHandler<GetAllDrRequestsByPatientIdQuery, IEnumerable<GetAllDrRequestsByPatientIdViewModel>>
{
    private readonly IAsyncDrRequestRepository repository;
    private readonly IMapper mapper;

    public GetAllDrRequestsByPatientIdQueryHandler(IAsyncDrRequestRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<GetAllDrRequestsByPatientIdViewModel>> Handle(GetAllDrRequestsByPatientIdQuery request, CancellationToken cancellationToken)
    {
        var allDiseasesByPatieantId = await repository.GetAllByPatieantIdAsync(request.PatientId.ToString());
        return mapper.Map<IEnumerable<GetAllDrRequestsByPatientIdViewModel>>(allDiseasesByPatieantId);
    }
}
