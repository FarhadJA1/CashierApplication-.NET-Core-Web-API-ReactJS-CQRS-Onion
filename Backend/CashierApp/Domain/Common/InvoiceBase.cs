using A.Domain.Enum;
using Domain.Entities;
namespace A.Domain.Common;
public abstract class InvoiceBase
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public int UserId { get; set; }
    public int CustomerId { get; set; }

    public abstract InvoiceType InvoiceType { get; }


    public IList<InvoiceDetail> Details { get; set; } = new List<InvoiceDetail>(0);
}
