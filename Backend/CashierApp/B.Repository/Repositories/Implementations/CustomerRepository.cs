using B.Repository.Data;
using B.Repository.Repositories.Interfaces;
using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace B.Repository.Repositories.Implementations;
public class CustomerRepository : ICustomerRepository
{
    
    public Task CreateAsync(Customer entity)
    {
        AppDbContext.OpenConnection();
        AppDbContext.sqlConnection.Query<Customer>(@"INSERT INTO [dbo].[Customers] ([Name], [Surname], [PhoneNumber])
                                                          VALUES (@Name,@Surname,@PhoneNumber)", entity);
        AppDbContext.CloseConnection();
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Customer entity)
    {
        throw new NotImplementedException();
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
                                                                            WHERE Id = {id}").FirstOrDefault();
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

    public Task UpdateAsync(Customer entity)
    {
        throw new NotImplementedException();
    }
}
