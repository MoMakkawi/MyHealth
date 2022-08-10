using AutoMapper;
using MediatR;

using MyHealth.Application.Contracts;
using MyHealth.Domain;

namespace MyHealth.Application.Features.Diseases.Commands.UpdateDiseases;

public class UpdateDiseasesHandler:IRequestHandler<UpdateDiseasesCommand>
{
    private readonly IAsyncRepository<Disease> repository;
    private readonly IMapper mapper;

    public UpdateDiseasesHandler(IAsyncRepository<Disease> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateDiseasesCommand request, CancellationToken cancellationToken)
    {
        Disease disease = mapper.Map<Disease>(request);
        await repository.UpdateAsync(disease);

        return Unit.Value;
    }
}
