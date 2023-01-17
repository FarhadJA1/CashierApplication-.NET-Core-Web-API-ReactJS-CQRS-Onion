using C.Service.DTOs.ProductDTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace C.Service.CQRS.Commands.ProductCommands;
public class CreateProductCommand : IRequest<CreateProductDTO>
{
    [Required]
    public string Name { get; set; } = string.Empty;


}
