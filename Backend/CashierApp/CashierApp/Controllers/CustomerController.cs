using C.Service.CQRS.Commands.CustomerCommands;
using C.Service.CQRS.Queries.CustomerQueries;
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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        GetAllCustomersQuery getAllCustomersQuery = new();
        return Ok(await _mediator.Send(getAllCustomersQuery));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        GetCustomerByIdQuery getCustomerByIdQuery = new()
        {
            Id = id
        };
        return Ok(await _mediator.Send(getCustomerByIdQuery));
    }

}

