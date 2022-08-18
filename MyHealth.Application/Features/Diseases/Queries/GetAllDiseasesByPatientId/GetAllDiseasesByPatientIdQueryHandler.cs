using AutoMapper;
using MediatR;
using MyHealth.Application.Contracts;

namespace MyHealth.Application.Features.Diseases.Queries.GetAllDiseasesByPatientId;

public class GetAllDiseasesByPatientIdQueryHandler
    : IRequestHandler<GetAllDiseasesByPatientIdQuery, List<GetAllDiseasesByPatientIdViewModel>>
{
    private readonly IAsyncDiseaseRepository repository;
    private readonly IMapper mapper;

    public GetAllDiseasesByPatientIdQueryHandler(IAsyncDiseaseRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<List<GetAllDiseasesByPatientIdViewModel>> Handle(GetAllDiseasesByPatientIdQuery request, CancellationToken cancellationToken)
    {
        var allDiseasesByPatieantId = await repository.GetAllByPatieantIdAsync(request.PatientId);
        return mapper.Map <List<GetAllDiseasesByPatientIdViewModel>>(allDiseasesByPatieantId);
    }
}
