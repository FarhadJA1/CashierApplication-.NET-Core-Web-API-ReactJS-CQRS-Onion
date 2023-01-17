using C.Service.DTOs.CustomerDTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace C.Service.CQRS.Commands.CustomerCommands;
public class UpdateCustomerCommand : IRequest<bool>
{
    [Required]
    public int Id { get; set; }
    public CustomerUpdateDTO UpdateDTO { get; set; } = default!;
}
