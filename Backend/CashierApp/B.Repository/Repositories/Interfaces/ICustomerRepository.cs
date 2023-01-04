using Domain.Entities;
namespace B.Repository.Repositories.Interfaces;
public interface ICustomerRepository : IRepository<Customer>
{
    Task UpdateAsync(int id, Customer entity);
}
