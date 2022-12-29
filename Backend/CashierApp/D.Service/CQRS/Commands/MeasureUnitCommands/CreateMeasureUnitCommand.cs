using C.Service.DTOs.MeasureUnitDTOs;
using MediatR;

namespace C.Service.CQRS.Commands.MeasureUnitCommands;
public class CreateMeasureUnitCommand : IRequest<CreateMeasureUnitDTO>
{
    public string Name { get; set; } = string.Empty;
}
