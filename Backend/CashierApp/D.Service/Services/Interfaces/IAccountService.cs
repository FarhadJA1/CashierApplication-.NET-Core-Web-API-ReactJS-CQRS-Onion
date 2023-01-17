using C.Service.DTOs.AccountDtos;
using Domain.Entities;

namespace C.Service.Services.Interfaces;
public interface IAccountService
{
    Task<string> LoginAsync(LoginDto loginDto);
    Task RegisterAsync(RegisterDto registerDto);
}
