using C.Service.CQRS.Commands.AccountCommands;
using C.Service.DTOs.AccountDtos;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.AccountCommandHandlers;
public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
{
    private readonly IAccountService _accountService;
    public RegisterCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }
    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        RegisterDto registerDto = new()
        {
            FirstName = request.FirstName,
            Surname = request.Surname,
            Username = request.Username,
            Password = request.Password
        };

        await _accountService.RegisterAsync(registerDto);

        return Unit.Value;
    }
}
