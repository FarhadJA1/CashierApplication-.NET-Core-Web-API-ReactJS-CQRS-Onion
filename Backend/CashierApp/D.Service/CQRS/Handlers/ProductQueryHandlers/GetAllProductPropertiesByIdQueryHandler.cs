using C.Service.CQRS.Queries.ProductQueries;
using C.Service.DTOs.ProductDTOs;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.ProductQueryHandlers;
public class GetAllProductPropertiesByIdQueryHandler : IRequestHandler<GetAllProductPropertiesByIdQuery, List<ProductPropertiesGetDto>>
{
    private readonly IProductService _productService;
    public GetAllProductPropertiesByIdQueryHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<List<ProductPropertiesGetDto>> Handle(GetAllProductPropertiesByIdQuery request, CancellationToken cancellationToken)
    {
        return await _productService.GetAllProductPropertiesById(request.Id);
    }
}
