using AutoMapper;
using MediatR;
using MyHealth.Application.Contracts;
using MyHealth.Domain.DTOs;

namespace MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsByPatientId;

public class GetAllDrRequestsByPatientIdQueryHandler
    : IRequestHandler<GetAllDrRequestsByPatientIdQuery, List<GetAllDrRequestsByPatientIdViewModel>>
{
    private readonly IAsyncDrRequestRepository repository;
    private readonly IMapper mapper;
    private readonly IAsyncUserRepository userRepository;

    public GetAllDrRequestsByPatientIdQueryHandler(IAsyncDrRequestRepository repository, IMapper mapper, IAsyncUserRepository userRepository)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.userRepository = userRepository;
    }

    public async Task<List<GetAllDrRequestsByPatientIdViewModel>> Handle(GetAllDrRequestsByPatientIdQuery request, CancellationToken cancellationToken)
    {
        var drRequestsByPatientId = await repository.GetAllByPatientIdAsync(request.PatientId);
        var drRequestsByPatientIdViewModels = mapper.Map<List<GetAllDrRequestsByPatientIdViewModel>>(drRequestsByPatientId);
        for (int i = 0; i < drRequestsByPatientId.Count; i++)
        {
            var userDTO = await userRepository.GetByIdAsync(drRequestsByPatientId[i].PatientId!);
            var doctor = mapper.Map<UserPersonalInfoDTO>(userDTO);

            drRequestsByPatientIdViewModels[i].Patient = doctor;
        }
        return drRequestsByPatientIdViewModels;
    }
}