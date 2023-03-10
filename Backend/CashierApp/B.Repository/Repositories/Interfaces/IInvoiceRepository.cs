using A.Domain.Common;
using A.Domain.Entities;
using A.Domain.Enum;
using Domain.Entities;

namespace B.Repository.Repositories.Interfaces;
public interface IInvoiceRepository
{
    Task CreateAsync(InvoiceBase entity);
    Task<List<VwInvoice>> GetAllAsync(InvoiceType? type);
    Task<List<InvoiceDetail>> GetInvoiceDetailsAsync(int id);
    Task<VwInvoice> GetInvoiceByCustomerAndUser(int customerId, int userId);
}

