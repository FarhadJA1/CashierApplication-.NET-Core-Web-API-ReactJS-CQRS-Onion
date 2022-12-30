using C.Service.DTOs.ProductDTOs;
using MediatR;

namespace C.Service.CQRS.Commands.ProductCommands;
public class CreateProductCommand : IRequest<CreateProductDTO>
{
    public string Name { get; set; } = string.Empty;
}
