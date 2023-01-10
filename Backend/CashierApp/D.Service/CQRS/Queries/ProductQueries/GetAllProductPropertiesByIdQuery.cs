using C.Service.DTOs.ProductDTOs;
using MediatR;

namespace C.Service.CQRS.Queries.ProductQueries;
public class GetAllProductPropertiesByIdQuery : IRequest<List<ProductPropertiesGetDto>>
{
    public int Id { get; set; }
}
