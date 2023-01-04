using C.Service.CQRS.Commands.ProductCommands;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.ProductCommandHandlers;
public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductService _productService;
    public UpdateProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        await _productService.UpdateAsync(request.Id, request.UpdateProductDTO, request.UpdateProductPropertiesDTO);
        return true;
    }

   
}
