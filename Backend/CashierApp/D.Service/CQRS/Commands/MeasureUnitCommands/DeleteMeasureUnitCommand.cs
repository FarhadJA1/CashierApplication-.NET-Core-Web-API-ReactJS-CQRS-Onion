using MediatR;
using System.ComponentModel.DataAnnotations;

namespace C.Service.CQRS.Commands.MeasureUnitCommands;
public class DeleteMeasureUnitCommand : IRequest<bool>
{
    [Required]
    public int Id { get; set; }
}
