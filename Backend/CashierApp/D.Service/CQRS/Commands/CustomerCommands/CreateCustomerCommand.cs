using C.Service.DTOs.CustomerDTos;
using MediatR;

namespace C.Service.CQRS.Commands.CustomerCommands;
public class CreateCustomerCommand:IRequest<CustomerCreateDTO>
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}
