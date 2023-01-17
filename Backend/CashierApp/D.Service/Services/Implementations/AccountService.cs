using B.Repository.Repositories.Interfaces;
using C.Service.DTOs.AccountDtos;
using C.Service.Helpers.Security;
using C.Service.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace C.Service.Services.Implementations;
public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITokenService _tokenService;
    public AccountService(IAccountRepository accountRepository,ITokenService tokenService)
    {
        _accountRepository = accountRepository;
        _tokenService = tokenService;
    }
    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        string hashedData = Hashing.ToSha256(loginDto.Password);

        AppUser appUser =  await _accountRepository.LoginAsync(loginDto.Username, hashedData);

        if (appUser is null) return null;

        return _tokenService.GenerateJwtToken(appUser.FirstName, appUser.FirstName, appUser.Surname);
        
    }

    public async Task RegisterAsync(RegisterDto registerDto)
    {
        string hashedData = Hashing.ToSha256(registerDto.Password);

        AppUser appUser = new()
        {
            FirstName = registerDto.FirstName,
            Surname =  registerDto.Surname,
            Username = registerDto.Username,
            Password =  hashedData
        };

        await _accountRepository.RegisterAsync(appUser);
    }
}
