using B.Repository.Repositories.Interfaces;
using Dapper;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using static Dapper.SqlMapper;

namespace B.Repository.Repositories.Implementations;
public class CustomerRepository : ICustomerRepository
{

    public Task CreateAsync(Customer entity)
    {
        using SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-1NLMPNC\SQLEXPRESS01; initial Catalog=CashierDbDapper;
                                                            Integrated Security=True;");

        connection.Query<Customer>(@"INSERT INTO [dbo].[Customers] ([Name], [Surname], [PhoneNumber])
                                     VALUES (@Name,@Surname,@PhoneNumber)"
                                     ,new {entity.Name, entity.Surname, entity.PhoneNumber});
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)    
    {
        using SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-1NLMPNC\SQLEXPRESS01; initial Catalog=CashierDbDapper;
                                                            Integrated Security=True;");

        connection.Query<Customer>(@"DELETE FROM Customers
                                     WHERE Id = @id", new { id })
                                     .FirstOrDefault();        
        return Task.CompletedTask;
    }

    public Task<List<Customer>> GetAllAsync()
    {
        using SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-1NLMPNC\SQLEXPRESS01; initial Catalog=CashierDbDapper;
                                                            Integrated Security=True;");

        List<Customer> customers = connection.Query<Customer>(@"SELECT * FROM [dbo].[Customers]").ToList();
        
        return Task.FromResult(customers);
    }

    public Task<Customer> GetAsync(int id)
    {
        using SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-1NLMPNC\SQLEXPRESS01; initial Catalog=CashierDbDapper;
                                                            Integrated Security=True;");
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
        using SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-1NLMPNC\SQLEXPRESS01; initial Catalog=CashierDbDapper;
                                                            Integrated Security=True;");

        connection.Query<Customer>(@"UPDATE Customers
                                     SET Name=@Name,Surname=@Surname,PhoneNumber=@PhoneNumber
                                     WHERE Id=@id",new { entity.Name, entity.Surname, entity.PhoneNumber, id });
    
        return Task.CompletedTask;
    }
}
