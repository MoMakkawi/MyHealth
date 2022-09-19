using MediatR;

using Microsoft.AspNetCore.Mvc;

using MyHealth.Application.Features.Users.Commands.CreateUser;
using MyHealth.Application.Features.Users.Commands.DeleteUser;
using MyHealth.Application.Features.Users.Commands.UpdateUser;
using MyHealth.Application.Features.Users.Queries.GetAllUsers;
using MyHealth.Application.Features.Users.Queries.GetUserById;
using MyHealth.Domain.DTOs;
using MyHealth.Domain.Helpers;

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

    [HttpGet( "GetUsers")]
    public async Task<List<GetAllUsersViewModel>> GetAllUsers()
    => await mediator.Send(new GetAllUsersQuery());

    [HttpGet("User/{id}")]
    public async Task<GetUserByIdViewModel> Get(Guid id)
    => await mediator.Send(new GetUserByIdQuery { UserId = id });
    

    [HttpPost("AddUser")]
    public async Task<AuthModel> Post([FromBody] CreateUserCommand createUser)
    {
        return await mediator.Send(createUser);
    }

    [HttpPut("UpdateUser")]
    public async Task<ActionResult> Put([FromBody] UpdateUserCommand updateUser)
    {
        await mediator.Send(updateUser);
        return Ok();
    }

    [HttpDelete("DelUser/{id}")]
    public async Task<ActionResult> DeleteUser(Guid id)
    {
        await mediator.Send(new DeleteUserCommand() { userId = id });
        return NoContent();
    }
}
