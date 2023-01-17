using Domain.Entities;

namespace B.Repository.Repositories.Interfaces;

public interface IAccountRepository
{
    Task RegisterAsync(AppUser newUser);
    Task<AppUser> LoginAsync(string username,string password);
}
