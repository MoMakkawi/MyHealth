using MediatR;
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

        [HttpGet("DiseasesPatient/{patientId}")]
        public async Task<ActionResult<List<GetAllDiseasesByPatientIdViewModel>>> GetAllDiseasesByPatientId(string patientId)
        {
            var diseases = await mediator.Send(new GetAllDiseasesByPatientIdQuery() { PatientId = patientId });
            return Ok(diseases);
        }

        [HttpGet("DiseaseDetails/{dieaseId}")]
        public async Task<ActionResult<GetDieaseDetailByDieaseIdViewModel>> GetDieaseDetailByDieaseId(string dieaseId)
        {
            var disease = await mediator.Send(new GetDieaseDetailByDieaseIdQuery() { DieaseId = new Guid(dieaseId) });
            return Ok(disease);
        }

        [HttpPost("AddDiease")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateDiseaseCommand createDiseaseCommand)
        {
            Guid id = await mediator.Send(createDiseaseCommand);
            return Ok(id);
        }

        [HttpDelete("DeleteDisease/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteDiseaseCommand = new DeleteDiseaseCommand() { DiseaseId = id };
            await mediator.Send(deleteDiseaseCommand);
            return NoContent();
        }

        [HttpPut("UpdateDiease")]
        public async Task<ActionResult> Update([FromBody] UpdateDiseasesCommand updateDiseasesCommand)
        {
            await mediator.Send(updateDiseasesCommand);
            return NoContent();
        }
    }
}