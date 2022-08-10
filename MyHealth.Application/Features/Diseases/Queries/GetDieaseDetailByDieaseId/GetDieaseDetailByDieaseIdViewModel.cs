﻿
using MyHealth.Application.DTOs;
using MyHealth.Domain;

namespace MyHealth.Application.Features.Diseases.Queries.GetDieaseDetailByDieaseId;
public class GetDieaseDetailByDieaseIdViewModel
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public string? Name { get; set; }
    public string? Discription { get; set; }
    public IEnumerable<AnalysisPicture>? AnalysisPicture { get; set; }
    public DoctorDTO? Doctor { get; set; }
}