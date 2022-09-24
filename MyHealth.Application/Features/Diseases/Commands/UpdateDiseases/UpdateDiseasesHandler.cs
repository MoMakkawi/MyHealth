using AutoMapper;
using MediatR;

using MyHealth.Application.Contracts;
using MyHealth.Domain;

namespace MyHealth.Application.Features.Diseases.Commands.UpdateDiseases;

public class UpdateDiseasesHandler : IRequestHandler<UpdateDiseasesCommand>
{
    private readonly IAsyncDiseaseRepository diseaseRepository;
    private readonly IMapper mapper;

    public UpdateDiseasesHandler(IAsyncDiseaseRepository diseaseRepository, IMapper mapper)
    {
        this.diseaseRepository = diseaseRepository;
        this.mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateDiseasesCommand request, CancellationToken cancellationToken)
    {
        Disease disease = mapper.Map<Disease>(request);

        await diseaseRepository.UpdateAsync(disease);

        return Unit.Value;
    }
}