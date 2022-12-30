using C.Service.CQRS.Queries.ProductQueries;
using C.Service.DTOs.ProductDTOs;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.ProductQueryHandlers;
public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductGetDTO>
{
    private readonly IProductService _productService;
    public GetProductByIdQueryHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<ProductGetDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _productService.GetAsync(request.Id);
    }
}
