using C.Service.CQRS.Commands.CustomerCommands;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.CustomerCommandHandlers;
public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand,bool>
{
    private readonly ICustomerService _customerService;
    public UpdateCustomerCommandHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        await _customerService.UpdateAsync(request.Id, request.UpdateDTO);
        return true;
    }
}
