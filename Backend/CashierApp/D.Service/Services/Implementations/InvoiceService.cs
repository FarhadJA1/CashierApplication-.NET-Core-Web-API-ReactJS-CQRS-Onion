using A.Domain.Common;
using A.Domain.Entities;
using A.Domain.Enum;
using AutoMapper;
using B.Repository.Repositories.Interfaces;
using C.Service.DTOs.InvoiceDTOs;
using C.Service.Services.Interfaces;
using Domain.Entities;

namespace C.Service.Services.Implementations;
public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IMapper _mapper;
    public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
    {
        _invoiceRepository = invoiceRepository;
        _mapper = mapper;
    }
    public async Task<bool> CreateInvoiceAsync(CreateInvoiceDTO createInvoice)
    {
        switch (createInvoice.InvoiceType)
        {
            case 1:

                await _invoiceRepository.CreateAsync(_mapper.Map<SellingInvoice>(createInvoice));
                return true;

            case 2:
                VwInvoice dbInvoice = await _invoiceRepository.GetInvoiceByCustomerAndUser(createInvoice.CustomerId, createInvoice.UserId);

                if (dbInvoice != null)
                {
                    await _invoiceRepository.CreateAsync(_mapper.Map<ReturnInvoice>(createInvoice));
                    return true;
                }
                return false;
                
            case 3:
                await _invoiceRepository.CreateAsync(_mapper.Map<ImportInvoice>(createInvoice));
                return true;
            default:
                return false;                
        }
    }

    public async Task<List<InvoiceGetDTO>> GetAllInvoicesAsync(InvoiceType? invoiceType = null)
    {
        List<VwInvoice> invoices = await _invoiceRepository.GetAllAsync(invoiceType);
        return _mapper.Map<List<InvoiceGetDTO>>(invoices);
    }

    public async Task<List<InvoiceDetailsGetDTO>> GetInvoiceDetailsByIdAsync(int id)
    {
        List<InvoiceDetail> invoiceDetails = await _invoiceRepository.GetInvoiceDetailsAsync(id);
        return _mapper.Map<List<InvoiceDetailsGetDTO>>(invoiceDetails);
    }
}
