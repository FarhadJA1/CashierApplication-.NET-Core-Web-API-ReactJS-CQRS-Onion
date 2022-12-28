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
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Customer entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<Customer>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Customer> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Customer entity)
    {
        throw new NotImplementedException();
    }
}
