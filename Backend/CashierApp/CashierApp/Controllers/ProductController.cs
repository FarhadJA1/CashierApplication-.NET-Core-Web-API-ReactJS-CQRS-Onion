using C.Service.CQRS.Commands.MeasureUnitCommands;
using C.Service.CQRS.Commands.ProductCommands;
using C.Service.CQRS.Queries.MeasureUnitQueries;
using C.Service.CQRS.Queries.ProductQueries;
using C.Service.DTOs.MeasureUnitDTOs;
using C.Service.DTOs.ProductDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace D.CashierApp.Controllers;
public class ProductController : BaseController
{
    private readonly IMediator _mediator;
    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand createProductCommand)
    {
        return Ok(await _mediator.Send(createProductCommand));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        GetAllProductsQuery getAllProductsQuery = new();
        return Ok(await _mediator.Send(getAllProductsQuery));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        GetProductByIdQuery getProductByIdQuery = new()
        {
            Id = id
        };
        return Ok(await _mediator.Send(getProductByIdQuery));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeleteProductCommand deleteProductCommand = new() { Id = id };
        return Ok(await _mediator.Send(deleteProductCommand));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
    {        
        return Ok(await _mediator.Send(updateProductCommand));
    }


    [HttpPut("SetDefault")]
    public async Task<IActionResult> SetProductPropertyToDefault([FromBody] SetProductPropertyDefaultCommand setProductPropertyDefaultCommand)
    {
        return Ok(await _mediator.Send(setProductPropertyDefaultCommand));
    }

    

}
