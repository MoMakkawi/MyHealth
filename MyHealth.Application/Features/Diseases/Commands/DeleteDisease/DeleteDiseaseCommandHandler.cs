using MediatR;

using MyHealth.Application.Contracts;
using MyHealth.Domain;

namespace MyHealth.Application.Features.Diseases.Commands.DeleteDisease;

public class DeleteDiseaseCommandHandler : IRequestHandler<DeleteDiseaseCommand>
{
    private readonly IAsyncAnalysisPictureRepository analysisPictureRepository;
    private readonly IAsyncDiseaseRepository diseaseRepository;

    public DeleteDiseaseCommandHandler(IAsyncDiseaseRepository diseaseRepository, IAsyncAnalysisPictureRepository analysisPictureRepository)
    {
        this.diseaseRepository = diseaseRepository;
        this.analysisPictureRepository = analysisPictureRepository;
    }

    public async Task<Unit> Handle(DeleteDiseaseCommand request, CancellationToken cancellationToken)
    {
        await analysisPictureRepository.DeleteAllAnalysisPicturesByDiseaseId(request.DiseaseId);
        await diseaseRepository.DeleteAsync(request.DiseaseId);

        return Unit.Value;
    }
}
