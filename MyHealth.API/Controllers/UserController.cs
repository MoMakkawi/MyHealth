using MediatR;

using Microsoft.AspNetCore.Mvc;

using MyHealth.Application.Features.Users.Commands.CreateUser;
using MyHealth.Application.Features.Users.Commands.UpdateUser;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyHealth.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator mediator;

    public UserController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public IEnumerable<string> GetUsers()
    {
        return new string[] { "value1", "value2" };
    }

    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    [HttpPost]
    public async Task<Guid> Post([FromBody] CreateUserCommand createUser)
    {
        var id = await mediator.Send(createUser);
        return id;
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UpdateUserCommand updateUser)
    {
        await mediator.Send(updateUser);
        return Ok();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
