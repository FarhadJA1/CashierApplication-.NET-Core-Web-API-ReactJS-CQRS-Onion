using B.Repository.Repositories.Interfaces;
using C.Repository.Exceptions;
using Dapper;
using Domain.Entities;

namespace B.Repository.Repositories.Implementations;
public class AccountRepository : BaseSqlRepository, IAccountRepository
{   
    public Task<AppUser> LoginAsync(string username, string password)
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();
            return connection.QueryFirstOrDefault<AppUser>("SELECT * FROM Users WHERE Username = @username AND Password = @password"
                                                                                                     , new { username, password });
        });
    }

    public Task RegisterAsync(AppUser newUser)
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();

            try
            {
                string sql = "INSERT [dbo].[Users] (FirstName,Surname,Username,Password) VALUES(@FirstName,@Surname,@Username,@Password)";
                connection.Execute(sql, new { newUser.FirstName, newUser.Surname, newUser.Username, newUser.Password });
            }
            catch (Exception)
            {
                throw new InvalidClientOperationException("This username already exists");
                
            }
            
            
        });       
    }
    

}
