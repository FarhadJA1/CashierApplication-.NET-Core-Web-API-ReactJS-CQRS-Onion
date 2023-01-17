using C.Service.DTOs.ProductDTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace C.Service.CQRS.Commands.ProductCommands;
public class UpdateProductCommand : IRequest<bool>
{
    [Required]
    public int Id { get; set; }
    public UpdateProductDTO UpdateProductDTO { get; set; } = default!;
    public UpdateProductPropertiesDTO UpdateProductPropertiesDTO { get; set; } = default!;
}

