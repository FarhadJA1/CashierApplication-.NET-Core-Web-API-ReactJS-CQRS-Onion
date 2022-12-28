using C.Service.CQRS.Commands.CustomerCommands;
using C.Service.DTOs.CustomerDTos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace D.CashierApp.Controllers;

public class CustomerController : BaseController
{
    private readonly IMediator _mediator;
    public CustomerController(IMediator mediator) 
    {
        _mediator= mediator;
    }

    [HttpPost]    
    public async Task<IActionResult> Create([FromBody] CustomerCreateDTO customerCreateDTO)
    {
        CreateCustomerCommand createCustomerCommand = new CreateCustomerCommand()
        {
             Name = customerCreateDTO.Name,
             Surname = customerCreateDTO.Surname,
             PhoneNumber = customerCreateDTO.PhoneNumber,
        };
        return Ok(await _mediator.Send(createCustomerCommand));
    }
}

