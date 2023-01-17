using C.Service.DTOs.MeasureUnitDTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace C.Service.CQRS.Commands.MeasureUnitCommands;
public class UpdateMeasureUnitCommand : IRequest<bool>
{
    [Required]
    public int Id { get; set; }
    public UpdateMeasureUnitDTO UpdateDTO { get; set; } = default!;
}
