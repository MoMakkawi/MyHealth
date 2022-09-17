﻿using MediatR;

using Microsoft.AspNetCore.Mvc;

using MyHealth.Application.Features.Users.Commands.CreateUser;
using MyHealth.Application.Features.Users.Commands.DeleteUser;
using MyHealth.Application.Features.Users.Commands.UpdateUser;
using MyHealth.Application.Features.Users.Queries.GetAllUsers;
using MyHealth.Application.Features.Users.Queries.GetUserById;

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

    [HttpGet( "GetAllUsers")]
    public async Task<List<GetAllUsersViewModel>> GetAllUsers()
    => await mediator.Send(new GetAllUsersQuery());

    [HttpGet("{id}")]
    public async Task<GetUserByIdViewModel> Get(Guid id)
        => await mediator.Send(new GetUserByIdQuery { UserId = id });
    

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

    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult> DeleteUser(Guid id)
    {
        await mediator.Send(new DeleteUserCommand() { userId = id });
        return NoContent();
    }
}