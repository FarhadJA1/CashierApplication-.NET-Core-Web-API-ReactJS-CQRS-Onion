using C.Service.CQRS.Commands.CustomerCommands;
using C.Service.CQRS.Commands.MeasureUnitCommands;
using C.Service.CQRS.Queries.CustomerQueries;
using C.Service.CQRS.Queries.MeasureUnitQueries;
using C.Service.DTOs.CustomerDTos;
using C.Service.DTOs.CustomerDTOs;
using C.Service.DTOs.MeasureUnitDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace D.CashierApp.Controllers;
public class MeasureUnitController : BaseController
{
    private readonly IMediator _mediator;
    public MeasureUnitController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMeasureUnitCommand createMeasureUnitCommand)
    {
        return Ok(await _mediator.Send(createMeasureUnitCommand));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        GetAllMeasureUnitsQuery getAllMeasureUnits = new();
        return Ok(await _mediator.Send(getAllMeasureUnits));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        GetMeasureUnitByIdQuery getMeasureUnitByIdQuery = new()
        {
            Id = id
        };
        return Ok(await _mediator.Send(getMeasureUnitByIdQuery));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeleteMeasureUnitCommand deleteMeasureUnitCommand = new() { Id = id };
        return Ok(await _mediator.Send(deleteMeasureUnitCommand));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMeasureUnitCommand updateMeasureUnitCommand)
    {        
        return Ok(await _mediator.Send(updateMeasureUnitCommand));
    }
}
