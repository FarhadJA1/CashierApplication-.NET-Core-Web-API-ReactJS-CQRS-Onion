namespace C.Service.Services.Interfaces;

public interface ITokenService
{
    string GenerateJwtToken(string username, string firstName,string lastName);
}
