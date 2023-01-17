using C.Service.CQRS.Commands.AccountCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace D.CashierApp.Controllers;
public class AccountController : BaseController
{
    private readonly IMediator _mediator;
    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("Register")]        
    public async Task<IActionResult> Register(RegisterCommand registerCommand)
    {
        if (!ModelState.IsValid) BadRequest();

        return Ok(await _mediator.Send(registerCommand));        

    }

    [HttpPost("Login")]    
    public async Task<IActionResult> Login(LoginCommand loginCommand)
    {
        if (!ModelState.IsValid) BadRequest();

        var result = await _mediator.Send(loginCommand);

        if (result is null) return NotFound("User is not found");

        return Ok(result);       
    }
}
