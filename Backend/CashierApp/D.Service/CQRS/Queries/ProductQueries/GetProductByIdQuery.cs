using C.Service.DTOs.ProductDTOs;
using MediatR;

namespace C.Service.CQRS.Queries.ProductQueries;
public class GetProductByIdQuery : IRequest<ProductGetDTO>
{
    public int Id { get; set; }
}
