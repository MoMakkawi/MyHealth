using MediatR;

namespace MyHealth.Application.Features.Diseases.Commands.DeleteDisease;

public class DeleteDiseaseCommand : IRequest
{
    public Guid DiseaseId { get; set; }    
}
