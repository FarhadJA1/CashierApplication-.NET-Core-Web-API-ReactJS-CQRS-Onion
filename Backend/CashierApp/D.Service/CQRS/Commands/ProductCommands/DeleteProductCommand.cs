using MediatR;

namespace C.Service.CQRS.Commands.ProductCommands;
public class DeleteProductCommand : IRequest<bool>
{
    public int Id { get; set; }
}
