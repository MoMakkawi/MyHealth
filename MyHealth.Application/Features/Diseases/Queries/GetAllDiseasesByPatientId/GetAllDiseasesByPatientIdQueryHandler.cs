using AutoMapper;
using MediatR;
using MyHealth.Application.Contracts;
using MyHealth.Domain.DTOs;

namespace MyHealth.Application.Features.Diseases.Queries.GetAllDiseasesByPatientId;

public class GetAllDiseasesByPatientIdQueryHandler
    : IRequestHandler<GetAllDiseasesByPatientIdQuery, List<GetAllDiseasesByPatientIdViewModel>>
{
    private readonly IAsyncDiseaseRepository repository;
    private readonly IMapper mapper;
    private readonly IAsyncUserRepository userRepository;

    public GetAllDiseasesByPatientIdQueryHandler(IAsyncDiseaseRepository repository, IMapper mapper, IAsyncUserRepository userRepository)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.userRepository = userRepository;
    }

    public async Task<List<GetAllDiseasesByPatientIdViewModel>> Handle(GetAllDiseasesByPatientIdQuery request, CancellationToken cancellationToken)
    {
        var diseases = await repository.GetAllByPatieantIdAsync(request.PatientId!);
        var diseaseViewModels = mapper.Map<List<GetAllDiseasesByPatientIdViewModel>>(diseases);

        for (int i = 0; i < diseases.Count; i++)
        {
            var userDTO = await userRepository.GetByIdAsync(diseases[i].DrId!);
            var doctor = mapper.Map<UserPersonalInfoDTO>(userDTO);

            diseaseViewModels[i].Doctor = doctor;
        }

        return diseaseViewModels;
    }
}