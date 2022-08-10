using MediatR;

using MyHealth.Application.Contracts;
using MyHealth.Domain;

namespace MyHealth.Application.Features.DrRequests.Commands.DeleteDrRequest;

public class DeleteDrRequestCommandHandler : IRequestHandler<DeleteDrRequestCommand>
{
    private readonly IAsyncRepository<DrRequest> repository;

    public DeleteDrRequestCommandHandler(IAsyncRepository<DrRequest> repository)
    {
        this.repository = repository;
    }

    public async Task<Unit> Handle(DeleteDrRequestCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.DrRequestId);
        return Unit.Value;
    }
}
