using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MyHealth.Application.Features.DrRequests.Commands.ChangeDrRequestStatus;
using MyHealth.Application.Features.DrRequests.Commands.DeleteDrRequest;
using MyHealth.Application.Features.DrRequests.Commands.SendDrRequestToPatient;
using MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsByDrId;
using MyHealth.Application.Features.DrRequests.Queries.GetAllDrRequestsByPatientId;

namespace MyHealth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrRequestController : ControllerBase
    {
        private readonly IMediator mediator;

        public DrRequestController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("DrReqDrId/{drId}")]
        public async Task<ActionResult<List<GetAllDrRequestsByDrIdViewModel>>> GetAllDrRequestsByDrId(Guid drId)
        {
            var diseases = await mediator.Send(new GetAllDrRequestsByDrIdQuery() { DrId = drId });
            return Ok(diseases);
        }

        [HttpGet("DrReqPatId/{patientId}")]
        public async Task<ActionResult<List<GetAllDrRequestsByPatientIdViewModel>>> GetAllDrRequestsByPatientId(Guid patientId)
        {
            var diseases = await mediator.Send(new GetAllDrRequestsByPatientIdQuery() { PatientId = patientId });
            return Ok(diseases);
        }

        [HttpPost(Name = "AddDrReq")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateDrRequestCommand createDrRequestCommand)
        {
            Guid id = await mediator.Send(createDrRequestCommand);
            return Ok(id);
        }

        [HttpDelete("DelDrReq/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteDrRequestCommand = new DeleteDrRequestCommand() { Id = id };
            await mediator.Send(deleteDrRequestCommand);
            return NoContent();
        }

        [HttpPut( "UpdateDrReqStatus")]
        public async Task<ActionResult> Update([FromBody] UpdateDrRequestStatusCommand updateDrRequestStatusCommand)
        {
            await mediator.Send(updateDrRequestStatusCommand);
            return NoContent();
        }
    }
}
