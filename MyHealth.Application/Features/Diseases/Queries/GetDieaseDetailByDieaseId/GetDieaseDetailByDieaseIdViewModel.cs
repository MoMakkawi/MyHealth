﻿using MyHealth.Domain;
using MyHealth.Domain.DTOs;

namespace MyHealth.Application.Features.Diseases.Queries.GetDieaseDetailByDieaseId;

public class GetDieaseDetailByDieaseIdViewModel
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public string? Name { get; set; }
    public string? Discription { get; set; }
    public ICollection<Picture?>? AnalysisPictures { get; set; }
    public UserPersonalInfoDTO? Doctor { get; set; }
}