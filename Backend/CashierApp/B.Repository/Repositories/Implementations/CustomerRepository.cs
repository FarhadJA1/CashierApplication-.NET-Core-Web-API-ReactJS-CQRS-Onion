using B.Repository.Repositories.Interfaces;
using Dapper;
using Domain.Entities;
using static Dapper.SqlMapper;

namespace B.Repository.Repositories.Implementations;


public class CustomerRepository : BaseSqlRepository,ICustomerRepository
{

    public Task CreateAsync(Customer entity)
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();           
            
            string sql = "INSERT INTO [dbo].[Customers] ([Name], [Surname], [PhoneNumber],[SoftDelete]) VALUES (@Name,@Surname,@PhoneNumber,0)";

            connection.Execute( sql , new { entity.Name, entity.Surname, entity.PhoneNumber });
        });        
    }

    public Task DeleteAsync(int id)    
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();

            connection.Execute($"UPDATE Customers SET SoftDelete = 1 WHERE Id = {id}");
        });        
    }

    public Task<List<Customer>> GetAllAsync()
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();

            var result = connection.Query<Customer>("SELECT * FROM [dbo].[Customers] WHERE SoftDelete = 0 ORDER BY Id DESC").ToList();      
                        
            return result;
        });               
    }    

    public Task<Customer> GetAsync(int id)
    {
        return Task.Run(() => 
        {
            using var connection = OpenConnection();

            return connection.QueryFirstOrDefault<Customer>($"SELECT TOP(1) * FROM Customers WHERE Id = {id} AND SoftDelete = 0");
        });
    }

    public Task UpdateAsync(int id,Customer entity)
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();

            string sql = @"UPDATE Customers
                           SET Name = @Name,Surname = @Surname,PhoneNumber = @PhoneNumber
                           WHERE Id = @id";

            connection.Execute(sql, new { entity.Name, entity.Surname, entity.PhoneNumber, id });
        });        
    }
}
