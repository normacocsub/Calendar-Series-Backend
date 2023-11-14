using Aplication.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[Controller]")]
[ApiController]
//[Authorize(Policy = "UserOnly")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> RegisterUser([FromBody] AddUserCommand command)
    {
        var userReponse = await _mediator.Send(command);
        return Ok(userReponse);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var(loginResponse, token) = await _mediator.Send(command);
        if (loginResponse.Succeeded) return Ok(new { Token = token});
        return BadRequest(loginResponse);
    }
}