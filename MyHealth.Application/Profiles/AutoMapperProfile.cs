
using AutoMapper;

using MyHealth.Application.Features.Diseases.Commands.CreateDisease;
using MyHealth.Application.Features.Diseases.Commands.DeleteDisease;
using MyHealth.Application.Features.Diseases.Commands.UpdateDiseases;
using MyHealth.Application.Features.Diseases.Queries.GetDieaseDetailByDieaseId;
using MyHealth.Application.Features.DrRequests.Commands.ChangeDrRequestStatus;
using MyHealth.Application.Features.DrRequests.Commands.DeleteDrRequest;
using MyHealth.Application.Features.DrRequests.Commands.SendDrRequestToPatient;
using MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsByDrId;
using MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsByPatientId;
using MyHealth.Application.Features.Users.Commands.CreateUser;
using MyHealth.Application.Features.Users.Commands.UpdateUser;
using MyHealth.Application.Features.Users.Queries.GetAllUsers;
using MyHealth.Application.Features.Users.Queries.GetUserById;
using MyHealth.Domain;
using MyHealth.Domain.DTOs;


namespace MyHealth.Application.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Disease, CreateDiseaseCommand>()
            .ForMember(dest => dest.DrId , opt => opt.MapFrom(src => new Guid(src.DrId!)))
            .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => new Guid(src.PatientId!)))
            .ReverseMap();
        CreateMap<Disease, UpdateDiseasesCommand>().ReverseMap();
        CreateMap<Disease, DeleteDiseaseCommand>().ReverseMap();
        CreateMap<Disease, GetDieaseDetailByDieaseIdViewModel>()
            .ForMember(dest => dest.Doctor, opt => opt.Ignore())
            .ReverseMap();
            

        CreateMap<Disease, GetAllDrRequestsByDrIdViewModel>().ReverseMap();
        CreateMap<Disease, GetAllDrRequestsByPatientIdViewModel>().ReverseMap();

        CreateMap<DrRequest, CreateDrRequestCommand>().ReverseMap();
        CreateMap<DrRequest, UpdateDrRequestStatusCommand>().ReverseMap();
        CreateMap<DrRequest, DeleteDrRequestCommand>().ReverseMap();

        CreateMap<ApplicationUserDTO, CreateUserCommand>().ReverseMap();
        CreateMap<ApplicationUserDTO, UpdateUserCommand>().ReverseMap();
        CreateMap<ApplicationUserDTO, GetAllUsersViewModel>()
            .ReverseMap();
        CreateMap<ApplicationUserDTO, GetUserByIdViewModel>()
            .ReverseMap();

        CreateMap<ApplicationUserDTO,UserPersonalInfoDTO>();
    }
}
