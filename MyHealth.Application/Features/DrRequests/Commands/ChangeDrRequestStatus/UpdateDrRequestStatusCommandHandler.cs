using AutoMapper;

using MediatR;

using MyHealth.Application.Contracts;
using MyHealth.Domain;

namespace MyHealth.Application.Features.DrRequests.Commands.ChangeDrRequestStatus;

public class UpdateDrRequestStatusCommandHandler : IRequestHandler<UpdateDrRequestStatusCommand>
{
    private readonly IAsyncDrRequestRepository repository;
    private readonly IMapper mapper;

    public UpdateDrRequestStatusCommandHandler(IAsyncDrRequestRepository repository , IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;   
    }

    public async Task<Unit> Handle(UpdateDrRequestStatusCommand request, CancellationToken cancellationToken)
{
        DrRequest drRequest = mapper.Map<DrRequest>(request);
        await repository.UpdateAsync(drRequest);

        return Unit.Value;
    }
}
