using C.Service.CQRS.Commands.ProductCommands;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.ProductCommandHandlers;
public class SetProductPropertyDefaultCommandHandler : IRequestHandler<SetProductPropertyDefaultCommand, bool>
{
    private readonly IProductService _productService;
    public SetProductPropertyDefaultCommandHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<bool> Handle(SetProductPropertyDefaultCommand request, CancellationToken cancellationToken)
    {
        await _productService.SetProductPropertyToDefaultAsync(request.ProductId,request.MeasureUnitId, request.IsDefault);
        return true;
    }
}
