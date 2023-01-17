using A.Domain.Enum;
using Domain.Entities;

namespace C.Service.DTOs.InvoiceDTOs;
public class CreateInvoiceDTO
{
    public DateTime CreationDate { get; set; }
    public int UserId { get; set; }
    public int CustomerId { get; set; }
    public byte InvoiceType { get; set; }
    public IList<CreateInvoiceDetailsDTO> Details { get; set; } = new List<CreateInvoiceDetailsDTO>(0);
}
