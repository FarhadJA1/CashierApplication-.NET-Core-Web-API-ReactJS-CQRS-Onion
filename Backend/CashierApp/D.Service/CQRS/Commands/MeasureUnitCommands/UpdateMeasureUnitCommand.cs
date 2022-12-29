using C.Service.DTOs.MeasureUnitDTOs;
using MediatR;

namespace C.Service.CQRS.Commands.MeasureUnitCommands;
public class UpdateMeasureUnitCommand : IRequest<bool>
{
    public int Id { get; set; }
    public UpdateMeasureUnitDTO UpdateDTO { get; set; } = default!;
}
