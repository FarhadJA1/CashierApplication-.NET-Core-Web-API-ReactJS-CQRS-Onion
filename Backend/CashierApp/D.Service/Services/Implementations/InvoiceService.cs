using A.Domain.Entities;
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
    public async Task CreateImportInvoice(CreateInvoiceDTO createImportInvoice,CreateInvoiceDetailsDTO createInvoiceDetailsDTO)
    {
        await _invoiceRepository.CreateAsync(_mapper.Map<ImportInvoice>(createImportInvoice),_mapper.Map<InvoiceDetail>(createInvoiceDetailsDTO));
    }
}
