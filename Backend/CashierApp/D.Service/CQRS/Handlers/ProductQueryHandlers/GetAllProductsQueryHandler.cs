using C.Service.CQRS.Queries.ProductQueries;
using C.Service.DTOs.ProductDTOs;
using C.Service.Services.Implementations;
using C.Service.Services.Interfaces;
using Domain.Entities;
using MediatR;

namespace C.Service.CQRS.Handlers.ProductQueryHandlers;
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductGetDTO>>
{
    private readonly IProductService _productService;
    public GetAllProductsQueryHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<List<ProductGetDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _productService.GetAllAsync();
    }
}
