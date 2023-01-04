using A.Domain.Entities;
using C.Service.DTOs.InvoiceDTOs;

namespace C.Service.Services.Interfaces;
public interface IInvoiceService
{
    Task CreateImportInvoice(CreateInvoiceDTO importInvoice, CreateInvoiceDetailsDTO createInvoiceDetailsDTO);
}
