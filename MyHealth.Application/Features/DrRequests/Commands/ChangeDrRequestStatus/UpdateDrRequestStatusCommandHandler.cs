using AutoMapper;

using MediatR;

using MyHealth.Application.Contracts;
using MyHealth.Domain;

namespace MyHealth.Application.Features.DrRequests.Commands.ChangeDrRequestStatus;

public class UpdateDrRequestStatusCommandHandler : IRequestHandler<UpdateDrRequestStatusCommand>
{
    private readonly IAsyncDrRequestRepository repository;

    public UpdateDrRequestStatusCommandHandler(IAsyncDrRequestRepository repository , IMapper mapper)
    {
        this.repository = repository;
    }

    public async Task<Unit> Handle(UpdateDrRequestStatusCommand request, CancellationToken cancellationToken)
{
        DrRequest newDrRequest = await repository.GetByIdAsync(request.Id);
        newDrRequest.Status = request.Status;

        await repository.UpdateAsync(newDrRequest);

        return Unit.Value;
    }
}
