using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MyHealth.Application.Features.Diseases.Commands.CreateDisease;
using MyHealth.Application.Features.Diseases.Commands.DeleteDisease;
using MyHealth.Application.Features.Diseases.Commands.UpdateDiseases;
using MyHealth.Application.Features.Diseases.Queries.GetAllDiseasesByPatientId;
using MyHealth.Application.Features.Diseases.Queries.GetDieaseDetailByDieaseId;

namespace MyHealth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly IMediator mediator;

        public DiseaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{patientId}", Name = "GetAllPosts")]
        public async Task<ActionResult<List<GetAllDiseasesByPatientIdViewModel>>> GetAllDiseasesByPatientId(Guid patientId)
        {
            var diseases = await mediator.Send(new GetAllDiseasesByPatientIdQuery() { PatientId = patientId});
            return Ok(diseases);
        }

        [HttpGet("{dieaseId}", Name = "GetDieaseDetailByDieaseId")]
        public async Task<ActionResult<GetDieaseDetailByDieaseIdViewModel>> GetDieaseDetailByDieaseId(Guid dieaseId)
        {
            var disease = await mediator.Send(new GetDieaseDetailByDieaseIdQuery() { DieaseId = dieaseId });
            return Ok(disease);
        }

        [HttpPost(Name = "AddDiease")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateDiseaseCommand createDiseaseCommand)
        {
            Guid id = await mediator.Send(createDiseaseCommand);
            return Ok(id);
        }

        [HttpDelete("{id}", Name = "DeleteDiease")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteDiseaseCommand = new DeleteDiseaseCommand() { DiseaseId = id };
            await mediator.Send(deleteDiseaseCommand);
            return NoContent();
        }

        [HttpPut(Name = "UpdateDiease")]
        public async Task<ActionResult> Update([FromBody] UpdateDiseasesCommand updateDiseasesCommand)
        {
            await mediator.Send(updateDiseasesCommand);
            return NoContent();
        }
    }
}
