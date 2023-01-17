using C.Service.DTOs.CustomerDTos;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace C.Service.CQRS.Commands.CustomerCommands;
public class CreateCustomerCommand:IRequest<bool>
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Surname { get; set; } = string.Empty;
    [Required]
    public string PhoneNumber { get; set; } = string.Empty;
}
