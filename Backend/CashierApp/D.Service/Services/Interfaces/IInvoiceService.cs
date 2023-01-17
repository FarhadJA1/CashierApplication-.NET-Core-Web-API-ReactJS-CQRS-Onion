using A.Domain.Entities;
using A.Domain.Enum;
using C.Service.DTOs.InvoiceDTOs;

namespace C.Service.Services.Interfaces;
public interface IInvoiceService
{
    Task<bool> CreateInvoiceAsync(CreateInvoiceDTO importInvoice);
    Task<List<InvoiceGetDTO>> GetAllInvoicesAsync(InvoiceType? invoiceType = null);
    Task<List<InvoiceDetailsGetDTO>> GetInvoiceDetailsByIdAsync(int id);
}
