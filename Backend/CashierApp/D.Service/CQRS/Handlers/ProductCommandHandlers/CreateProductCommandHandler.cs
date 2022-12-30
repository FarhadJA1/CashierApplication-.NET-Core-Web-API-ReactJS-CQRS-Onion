using C.Service.CQRS.Commands.ProductCommands;
using C.Service.DTOs.CustomerDTos;
using C.Service.DTOs.ProductDTOs;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.ProductCommandHandlers;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductDTO>
{
    private readonly IProductService _productService;
    public CreateProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<CreateProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        CreateProductDTO createProductDTO = new()
        {
            Name = request.Name
        };
        await _productService.CreateAsync(createProductDTO);
        return await Task.FromResult(createProductDTO);
    }
}
