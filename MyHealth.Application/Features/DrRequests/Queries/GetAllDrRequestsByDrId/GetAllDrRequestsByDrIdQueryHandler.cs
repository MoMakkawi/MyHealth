using AutoMapper;
using MediatR;
using MyHealth.Application.Contracts;
using MyHealth.Domain.DTOs;

namespace MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsByDrId;

public class GetAllDrRequestsByDrIdQueryHandler
    : IRequestHandler<GetAllDrRequestsByDrIdQuery, List<GetAllDrRequestsByDrIdViewModel>>
{
    private readonly IAsyncDrRequestRepository repository;
    private readonly IMapper mapper;
    private readonly IAsyncUserRepository userRepository;

    public GetAllDrRequestsByDrIdQueryHandler(IAsyncDrRequestRepository repository, IMapper mapper, IAsyncUserRepository userRepository)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.userRepository = userRepository;
    }

    public async Task<List<GetAllDrRequestsByDrIdViewModel>> Handle(GetAllDrRequestsByDrIdQuery request, CancellationToken cancellationToken)
    {
        var drRequestsByDrId = await repository.GetAllByDrIdAsync(request.DrId);
        var drRequestsByDrIdVM = mapper.Map<List<GetAllDrRequestsByDrIdViewModel>>(drRequestsByDrId);
        for (int i = 0; i < drRequestsByDrId.Count; i++)
        {
            var userDTO = await userRepository.GetByIdAsync(drRequestsByDrId[i].DrId!);
            var doctor = mapper.Map<UserPersonalInfoDTO>(userDTO);

            drRequestsByDrIdVM[i].Doctor = doctor;
        }
        return drRequestsByDrIdVM;
    }
}