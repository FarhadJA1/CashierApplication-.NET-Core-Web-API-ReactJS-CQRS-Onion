using A.Domain.Enum;
using Domain.Entities;

namespace C.Service.DTOs.InvoiceDTOs;
public class InvoiceGetDTO
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public int UserId { get; set; }
    public int CustomerId { get; set; }
    public InvoiceType InvoiceType { get; set; }
    public IList<InvoiceDetailsGetDTO> Details { get; set; } = new List<InvoiceDetailsGetDTO>(0);
}
