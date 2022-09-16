using AutoMapper;
using MediatR;
using MyHealth.Application.Contracts;
using MyHealth.Domain.DTOs;

namespace MyHealth.Application.Features.Diseases.Queries.GetDieaseDetailByDieaseId;

public class GetDieaseDetailByDieaseIdQueryHandler
    : IRequestHandler<GetDieaseDetailByDieaseIdQuery,GetDieaseDetailByDieaseIdViewModel>
{
    private readonly IAsyncDiseaseRepository repository;
    private readonly IMapper mapper;
    private readonly IAsyncUserRepository userRepository;

    public GetDieaseDetailByDieaseIdQueryHandler(IAsyncDiseaseRepository repository, IMapper mapper , IAsyncUserRepository userRepository)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.userRepository = userRepository;
    }

    public async Task<GetDieaseDetailByDieaseIdViewModel> Handle(GetDieaseDetailByDieaseIdQuery request, CancellationToken cancellationToken)
    {
        var dieaseDetail = await repository.GetByIdAsync(request.DieaseId!);
        var userDTO = await userRepository.GetByIdAsync(dieaseDetail.DrId!);
        var doctor = mapper.Map<UserPersonalInfoDTO>(userDTO);

        var dieaseDetailViewModel = mapper.Map<GetDieaseDetailByDieaseIdViewModel>(dieaseDetail);
        dieaseDetailViewModel.Doctor = doctor;

        return dieaseDetailViewModel;
    }
}
