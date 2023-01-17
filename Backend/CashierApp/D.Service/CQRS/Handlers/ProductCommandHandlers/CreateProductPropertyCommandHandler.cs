using C.Service.CQRS.Commands.ProductCommands;
using C.Service.DTOs.ProductDTOs;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.ProductCommandHandlers;
public class CreateProductPropertyCommandHandler : IRequestHandler<CreateProductPropertyCommand>
{
    private readonly IProductService _productService;
    public CreateProductPropertyCommandHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<Unit> Handle(CreateProductPropertyCommand request, CancellationToken cancellationToken)
    {
        CreateProductPropertyDto createProductPropertyDto = new()
        {
            ProductId= request.ProductId,
            MeasureUnitId= request.MeasureUnitId,
            PurchasePrice= request.PurchasePrice,
            GrossPrice= request.GrossPrice,
            SellingPrice= request.SellingPrice
        };

        await _productService.CreateProductPropertiesAsync(createProductPropertyDto);

        return Unit.Value;
    }
}
