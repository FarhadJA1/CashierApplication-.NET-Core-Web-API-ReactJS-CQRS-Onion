using A.Domain.Enum;
using C.Service.CQRS.Commands.InvoiceCommands;
using C.Service.CQRS.Queries.InvoiceQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace D.CashierApp.Controllers;

public class InvoiceController : BaseController
{
    private readonly IMediator _mediator;
    public InvoiceController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateInvoiceCommand createImportInvoiceCommand)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _mediator.Send(createImportInvoiceCommand));
        }
        else
        {
            return BadRequest("Not all the fields filled properly");
        }
        
    }

    [HttpGet("{type?}")]
    public async Task<IActionResult> GetAll([FromRoute] byte type=0)
    {
        GetAllInvoicesQuery getAllInvoicesQuery = new();
        if (Enum.IsDefined(typeof(InvoiceType),type))
        {
            InvoiceType invoiceType = (InvoiceType)type;
            getAllInvoicesQuery.InvoiceType = invoiceType;
        }

        var result = await _mediator.Send(getAllInvoicesQuery);

        if (result.Count>0)
        {
            return Ok(result);
        }
        else
        {
            return NotFound("No invoice was found");
        }
       
    }

    [HttpGet("InvoiceDetails/{id}")]
    public async Task<IActionResult> GetAllInvoiceDetails([FromRoute] int id)
    {
        GetInvoiceDetailsByIdQuery getInvoiceDetailsByIdQuery = new() { Id= id };

        var result = await _mediator.Send(getInvoiceDetailsByIdQuery);

        if (result.Count>0)
        {
            return Ok(result);
        }
        else
        {
            return NotFound("No invoice was found");
        }
    }
}
