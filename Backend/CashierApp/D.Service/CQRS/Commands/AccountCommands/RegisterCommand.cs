using MediatR;
using System.ComponentModel.DataAnnotations;

namespace C.Service.CQRS.Commands.AccountCommands;
public class RegisterCommand : IRequest
{
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string Surname { get; set; } = string.Empty;
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required,Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = string.Empty;
}
