using MediatR;

namespace C.Service.CQRS.Commands.MeasureUnitCommands;
public class DeleteMeasureUnitCommand : IRequest<bool>
{
    public int Id { get; set; }
}
