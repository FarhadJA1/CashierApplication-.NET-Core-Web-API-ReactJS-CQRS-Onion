using C.Service.DTOs.ProductDTOs;
using Domain.Entities;
using MediatR;

namespace C.Service.CQRS.Queries.ProductQueries;
public class GetAllProductsQuery : IRequest<List<ProductGetDTO>>
{

}
