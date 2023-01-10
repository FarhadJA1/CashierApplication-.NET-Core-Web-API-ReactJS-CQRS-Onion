using A.Domain.Entities;
using A.Domain.Enum;
using C.Service.DTOs.InvoiceDTOs;

namespace C.Service.Services.Interfaces;
public interface IInvoiceService
{
    Task CreateInvoiceAsync(CreateInvoiceDTO importInvoice, CreateInvoiceDetailsDTO createInvoiceDetailsDTO);
    Task<List<InvoiceGetDTO>> GetAllInvoicesAsync(InvoiceType? invoiceType = null);
}
