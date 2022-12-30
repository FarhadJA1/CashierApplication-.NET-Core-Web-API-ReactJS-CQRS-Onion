using C.Service.CQRS.Commands.ProductCommands;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.ProductCommandHandlers;
public class DeleteProductQueryHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductService _productService;
    public DeleteProductQueryHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _productService.DeleteAsync(request.Id);
        return true;
    }
}
