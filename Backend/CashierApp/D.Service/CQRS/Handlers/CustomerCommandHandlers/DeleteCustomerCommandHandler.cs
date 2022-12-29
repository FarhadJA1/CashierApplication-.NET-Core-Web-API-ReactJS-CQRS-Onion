using C.Service.CQRS.Commands.CustomerCommands;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.CustomerCommandHandlers;
public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand,bool>
{
    private readonly ICustomerService _customerService;
    public DeleteCustomerCommandHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        await _customerService.DeleteAsync(request.Id);
        return true;
    }
}
