﻿
using AutoMapper;

using MyHealth.Application.Features.Diseases.Commands.CreateDisease;
using MyHealth.Application.Features.Diseases.Commands.DeleteDisease;
using MyHealth.Application.Features.Diseases.Commands.UpdateDiseases;
using MyHealth.Application.Features.Diseases.Queries.GetAllDiseasesByPatieantId;
using MyHealth.Application.Features.Diseases.Queries.GetDieaseDetailById;
using MyHealth.Application.Features.DrRequests.Commands.ChangeDrRequestStatus;
using MyHealth.Application.Features.DrRequests.Commands.DeleteDrRequest;
using MyHealth.Application.Features.DrRequests.Commands.SendDrRequestToPatient;
using MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsByDrId;
using MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsByPatientId;
using MyHealth.Domain;

namespace MyHealth.Application.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    { 
        CreateMap<Disease, GetAllDrRequestsByDrIdViewModel>().ReverseMap();
        CreateMap<Disease, GetAllDrRequestsByPatientIdViewModel>().ReverseMap();
        CreateMap<Disease, GetDieaseDetailByIdViewModel>().ReverseMap();

        CreateMap<Disease, CreateDiseaseCommand>().ReverseMap();
        CreateMap<Disease, DeleteDiseaseCommand>().ReverseMap();
        CreateMap<Disease, UpdateDiseasesCommand>().ReverseMap();

        CreateMap<DrRequest, UpdateDrRequestStatusCommand>().ReverseMap();
        CreateMap<DrRequest, DeleteDrRequestCommand>().ReverseMap();
        CreateMap<DrRequest, CreateDrRequestCommand>().ReverseMap();
    }
}
