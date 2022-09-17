using MediatR;

using MyHealth.Application.Contracts;
using MyHealth.Domain;

namespace MyHealth.Application.Features.DrRequests.Commands.DeleteDrRequest;

public class DeleteDrRequestCommandHandler : IRequestHandler<DeleteDrRequestCommand>
{
    private readonly IAsyncDrRequestRepository repository;

    public DeleteDrRequestCommandHandler(IAsyncDrRequestRepository repository)
    {
        this.repository = repository;
    }

    public async Task<Unit> Handle(DeleteDrRequestCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}
