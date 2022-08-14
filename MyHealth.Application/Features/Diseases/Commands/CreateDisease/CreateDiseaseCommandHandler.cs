using AutoMapper;

using MediatR;

using MyHealth.Application.Contracts;
using MyHealth.Domain;

namespace MyHealth.Application.Features.Diseases.Commands.CreateDisease;

public class CreateDiseaseCommandHandler : IRequestHandler<CreateDiseaseCommand , Guid>
{
    private readonly IAsyncDiseaseRepository diseaseRepository;
    private readonly IAsyncAnalysisPictureRepository analysisPictureRepository;
    private readonly IMapper mapper;

    public CreateDiseaseCommandHandler(IAsyncDiseaseRepository diseaseRepository , IAsyncAnalysisPictureRepository analysisPictureRepository, IMapper mapper)
    {
        this.diseaseRepository = diseaseRepository;
        this.analysisPictureRepository = analysisPictureRepository;
        this.mapper = mapper;
    }

    public async Task<Guid> Handle(CreateDiseaseCommand request, CancellationToken cancellationToken)
    {
        var disease = mapper.Map<Disease>(request);

        await new CreateDiseaseCommandValidator().ValidateAsync(request);

        await analysisPictureRepository.AddAnalysisPictures(request.AnalysisPictures);
        disease = await diseaseRepository.AddAsync(disease);

        return disease.Id;

    }
}
