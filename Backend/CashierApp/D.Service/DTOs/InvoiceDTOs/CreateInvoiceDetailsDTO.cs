﻿using A.Domain.Enum;

namespace C.Service.DTOs.InvoiceDTOs;
public class CreateInvoiceDetailsDTO
{   
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public int MeasureId { get; set; }
    public decimal Quantity { get; set; }
    
}
