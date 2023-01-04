using A.Domain.Enum;

namespace C.Service.DTOs.InvoiceDTOs;
public class CreateInvoiceDTO
{
    public DateTime CreationDate { get; set; }
    public int UserId { get; set; }
    public int CustomerId { get; set; }

    public  InvoiceType InvoiceType { get; }
}
