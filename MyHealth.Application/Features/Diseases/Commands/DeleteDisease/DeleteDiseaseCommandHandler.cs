using MediatR;

using MyHealth.Application.Contracts;
using MyHealth.Domain;

namespace MyHealth.Application.Features.Diseases.Commands.DeleteDisease;

public class DeleteDiseaseCommandHandler : IRequestHandler<DeleteDiseaseCommand>
{
    private IAsyncRepository<Disease> repository;

    public DeleteDiseaseCommandHandler(IAsyncRepository<Disease> repository)
    {
        this.repository = repository;
    }

    public async Task<Unit> Handle(DeleteDiseaseCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.DiseaseId);

        return Unit.Value;
    }
}
