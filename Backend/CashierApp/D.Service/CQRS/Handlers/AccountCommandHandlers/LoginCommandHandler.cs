using C.Service.CQRS.Commands.AccountCommands;
using C.Service.DTOs.AccountDtos;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.AccountCommandHandlers;
public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IAccountService _accountService;
    public LoginCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }
    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        LoginDto loginDto = new()
        {
            Username = request.Username,
            Password = request.Password,
        };
        var result = await _accountService.LoginAsync(loginDto);

        if (result == null) return null;

        return result;
    }
}
