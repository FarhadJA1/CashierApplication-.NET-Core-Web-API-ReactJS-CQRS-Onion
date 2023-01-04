using A.Domain.Common;
using Domain.Entities;

namespace B.Repository.Repositories.Interfaces;
public interface IInvoiceRepository
{
    Task CreateAsync(InvoiceBase entity,InvoiceDetail invoiceDetail);
    Task UpdateAsync(int id, InvoiceBase entity);
}

