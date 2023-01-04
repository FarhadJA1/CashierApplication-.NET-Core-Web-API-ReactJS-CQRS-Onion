using MediatR;

namespace C.Service.CQRS.Commands.ProductCommands;
public class SetProductPropertyDefaultCommand : IRequest<bool>
{
    public int ProductId { get; set; }
    public int MeasureUnitId { get; set; }
    public bool IsDefault { get; set; }
}
