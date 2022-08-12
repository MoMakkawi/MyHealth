using MediatR;

namespace MyHealth.Application.Features.Diseases.Queries.GetAllDiseasesByPatieantId;

public class GetAllDrRequestsByIdQuery : IRequest<IEnumerable<GetAllDrRequestsByIdViewModel>>
{
    //this DieaseId can be DieaseId of Dr/Patient 
    public Guid Id { get; set; }
}
