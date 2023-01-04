using C.Service.DTOs.ProductDTOs;
using MediatR;

namespace C.Service.CQRS.Commands.ProductCommands;
public class UpdateProductCommand : IRequest<bool>
{
    public int Id { get; set; }
    public UpdateProductDTO UpdateProductDTO { get; set; } = default!;
    public UpdateProductPropertiesDTO UpdateProductPropertiesDTO { get; set; } = default!;
}

