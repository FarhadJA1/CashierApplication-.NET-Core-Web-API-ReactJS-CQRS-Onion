using MediatR;
using System.ComponentModel.DataAnnotations;

namespace C.Service.CQRS.Commands.ProductCommands;
public class DeleteProductCommand : IRequest<bool>
{
    [Required]
    public int Id { get; set; }
}
