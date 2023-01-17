using C.Service.DTOs.MeasureUnitDTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace C.Service.CQRS.Commands.MeasureUnitCommands;
public class CreateMeasureUnitCommand : IRequest<CreateMeasureUnitDTO>
{
    [Required]
    public string Name { get; set; } = string.Empty;
}
