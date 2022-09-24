using AutoMapper;
using MediatR;
using MyHealth.Application.Contracts;

using MyHealth.Domain;

namespace MyHealth.Application.Features.DrRequests.Commands.SendDrRequestToPatient
{
    public class CreateDrRequestCommandHandler : IRequestHandler<CreateDrRequestCommand, Guid>
    {
        private readonly IAsyncDrRequestRepository repository;
        private readonly IMapper mapper;

        public CreateDrRequestCommandHandler(IAsyncDrRequestRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Guid> Handle(CreateDrRequestCommand request, CancellationToken cancellationToken)
        {
            var drRequest = mapper.Map<DrRequest>(request);

            drRequest = await repository.AddAsync(drRequest);

            return drRequest.Id;
        }
    }
}