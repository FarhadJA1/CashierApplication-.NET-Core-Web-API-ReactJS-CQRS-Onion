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
        return Ok(await _mediator.Send(createImportInvoiceCommand));
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
        
        return Ok(await _mediator.Send(getAllInvoicesQuery));
    }

    [HttpGet("InvoiceDetails/{id}")]
    public async Task<IActionResult> GetAllInvoiceDetails([FromRoute] int id)
    {
        GetInvoiceDetailsByIdQuery getInvoiceDetailsByIdQuery = new() { Id= id };
        return Ok(await _mediator.Send(getInvoiceDetailsByIdQuery));
    }
}
