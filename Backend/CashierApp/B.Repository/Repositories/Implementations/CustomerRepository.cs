using B.Repository.Repositories.Interfaces;
using Dapper;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using static Dapper.SqlMapper;

namespace B.Repository.Repositories.Implementations;
public class CustomerRepository : BaseSqlRepository,ICustomerRepository
{

    public Task CreateAsync(Customer entity)
    {
        using var connection = OpenConnection();

        connection.Query<Customer>(@"INSERT INTO [dbo].[Customers] ([Name], [Surname], [PhoneNumber],[SoftDelete])                                     
                                     VALUES (@Name,@Surname,@PhoneNumber,0)"
                                     ,new {entity.Name, entity.Surname, entity.PhoneNumber});
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)    
    {
        using var connection = OpenConnection();

        connection.Query<Customer>(@"UPDATE Customers
                                     SET SoftDelete = 1
                                     WHERE Id = @id", new { id });
                                           
        return Task.CompletedTask;
    }

    public Task<List<Customer>> GetAllAsync()
    {
        using var connection = OpenConnection();

        List<Customer> customers = connection.Query<Customer>(@"SELECT * FROM [dbo].[Customers] WHERE SoftDelete = 0
                                                                ORDER BY Id DESC").ToList();
        
        return Task.FromResult(customers);
    }

    public Task<Customer> GetAsync(int id)
    {
        using var connection = OpenConnection();

        Customer? customer = connection.Query<Customer>(@"SELECT * FROM Customers
                                                           WHERE Id = @id", new { id })
                                                           .FirstOrDefault();       

        if (customer != null)
        {
            return Task.FromResult(customer);
        }
        else
        {
            throw new NullReferenceException("Customer not found!");
        }
        

    }

    public Task UpdateAsync(int id,Customer entity)
    {
        using var connection = OpenConnection();

        connection.Query<Customer>(@"UPDATE Customers
                                     SET Name=@Name,Surname=@Surname,PhoneNumber=@PhoneNumber
                                     WHERE Id=@id",new { entity.Name, entity.Surname, entity.PhoneNumber, id });
    
        return Task.CompletedTask;
    }
}
