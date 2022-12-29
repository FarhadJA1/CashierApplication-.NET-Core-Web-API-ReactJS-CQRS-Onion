using B.Repository.Data;
using B.Repository.Repositories.Interfaces;
using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static Dapper.SqlMapper;

namespace B.Repository.Repositories.Implementations;
public class CustomerRepository : ICustomerRepository
{

    public Task CreateAsync(Customer entity)
    {
        AppDbContext.OpenConnection();
        AppDbContext.sqlConnection.Query<Customer>(@"INSERT INTO [dbo].[Customers] ([Name], [Surname], [PhoneNumber])
                                                     VALUES (@Name,@Surname,@PhoneNumber)"
                                                     ,new {entity.Name, entity.Surname, entity.PhoneNumber});
        AppDbContext.CloseConnection();
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)    
    {

        AppDbContext.OpenConnection();
        AppDbContext.sqlConnection.Query<Customer>(@$"DELETE FROM Customers
                                                      WHERE Id = {id}")
                                                      .FirstOrDefault();
        AppDbContext.CloseConnection();
        return Task.CompletedTask;

    }

    public Task<List<Customer>> GetAllAsync()
    {
        AppDbContext.OpenConnection();
        List<Customer> customers = AppDbContext.sqlConnection.Query<Customer>(@"SELECT * FROM [dbo].[Customers]").ToList();
        AppDbContext.CloseConnection();
        return Task.FromResult(customers);
    }

    public Task<Customer> GetAsync(int id)
    {
        AppDbContext.OpenConnection();
        Customer? customer = AppDbContext.sqlConnection.Query<Customer>(@$"SELECT * FROM Customers
                                                                            WHERE Id = {id}")
                                                                            .FirstOrDefault();
        AppDbContext.CloseConnection();

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
        AppDbContext.OpenConnection();
        AppDbContext.sqlConnection.Query<Customer>(@"UPDATE Customers
                                                      SET Name=@Name,Surname=@Surname,PhoneNumber=@PhoneNumber
                                                      WHERE Id=@id",new { entity.Name, entity.Surname, entity.PhoneNumber, id });
        AppDbContext.CloseConnection();
        return Task.CompletedTask;
    }
}
