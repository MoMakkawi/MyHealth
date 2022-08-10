using AutoMapper;

using MediatR;

using MyHealth.Application.Contracts;
using MyHealth.Domain;

namespace MyHealth.Application.Features.Diseases.Commands.CreateDisease;

public class CreateDiseaseCommandHandler : IRequestHandler<CreateDiseaseCommand , Guid>
{
    private readonly IAsyncRepository<Disease> repository;
    private readonly IMapper mapper;

    public CreateDiseaseCommandHandler(IAsyncRepository<Disease> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<Guid> Handle(CreateDiseaseCommand request, CancellationToken cancellationToken)
    {
        var disease = mapper.Map<Disease>(request);

        await new CreateDiseaseCommandValidator().ValidateAsync(request);

        disease = await repository.AddAsync(disease);

        return disease.Id;


    }
}
