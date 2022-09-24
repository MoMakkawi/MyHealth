using MediatR;

using MyHealth.Application.Contracts;

namespace MyHealth.Application.Features.Diseases.Commands.DeleteDisease;

public class DeleteDiseaseCommandHandler : IRequestHandler<DeleteDiseaseCommand>
{
    private readonly IAsyncDiseaseRepository diseaseRepository;

    public DeleteDiseaseCommandHandler(IAsyncDiseaseRepository diseaseRepository)
    {
        this.diseaseRepository = diseaseRepository;
    }

    public async Task<Unit> Handle(DeleteDiseaseCommand request, CancellationToken cancellationToken)
    {
        await diseaseRepository.DeleteAsync(request.DiseaseId);

        return Unit.Value;
    }
}