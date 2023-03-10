using C.Service.CQRS.Commands.CustomerCommands;
using C.Service.DTOs.CustomerDTos;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.CustomerCommandHandlers;
public class CustomerCreateCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
{
    private readonly ICustomerService _customerService;
    public CustomerCreateCommandHandler(ICustomerService customerService)
    {
        _customerService= customerService;
    }
    public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
           CustomerCreateDTO customerCreateDTO = new()
           {
               Name = request.Name,
               Surname = request.Surname,
               PhoneNumber = request.PhoneNumber
           };
           await _customerService.CreateAsync(customerCreateDTO);
           return true;       
    }
}
