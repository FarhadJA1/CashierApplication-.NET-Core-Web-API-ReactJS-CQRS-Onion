using C.Service.CQRS.Commands.InvoiceCommands;
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
    [HttpPost("Import")]
    public async Task<IActionResult> Create([FromBody] CreateImportInvoiceCommand createImportInvoiceCommand)
    {
        return Ok(await _mediator.Send(createImportInvoiceCommand));
    }
}
