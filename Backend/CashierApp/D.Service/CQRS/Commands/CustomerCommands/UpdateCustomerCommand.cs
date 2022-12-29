using C.Service.DTOs.CustomerDTOs;
using MediatR;

namespace C.Service.CQRS.Commands.CustomerCommands;
public class UpdateCustomerCommand : IRequest<bool>
{
    public int Id { get; set; }
    public CustomerUpdateDTO UpdateDTO { get; set; } = default!;
}
