using C.Service.CQRS.Commands.CustomerCommands;
using C.Service.CQRS.Queries.CustomerQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace D.CashierApp.Controllers;

[Authorize]
public class CustomerController : BaseController
{
    private readonly IMediator _mediator;
    public CustomerController(IMediator mediator) 
    {
        _mediator = mediator;
    }

    [HttpPost]    
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand createCustomerCommand)
    {   
         return Ok(await _mediator.Send(createCustomerCommand));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        GetAllCustomersQuery getAllCustomersQuery = new();

        var result = await _mediator.Send(getAllCustomersQuery);

        if (result.Count==0) return NotFound("No customer were found");

        return Ok(result);
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeleteCustomerCommand deleteCustomerCommand = new() { Id = id };
        return Ok(await _mediator.Send(deleteCustomerCommand));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand updateCustomerCommand)
    {   
        
        return Ok(await _mediator.Send(updateCustomerCommand));
    }

}

