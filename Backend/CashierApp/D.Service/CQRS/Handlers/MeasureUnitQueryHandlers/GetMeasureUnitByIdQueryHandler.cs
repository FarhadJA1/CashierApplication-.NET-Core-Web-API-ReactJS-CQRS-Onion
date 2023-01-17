using C.Repository.Exceptions;
using C.Service.CQRS.Queries.MeasureUnitQueries;
using C.Service.DTOs.MeasureUnitDTOs;
using C.Service.Services.Implementations;
using C.Service.Services.Interfaces;
using Domain.Entities;
using MediatR;

namespace C.Service.CQRS.Handlers.MeasureUnitQueryHandlers;
public class GetMeasureUnitByIdQueryHandler : IRequestHandler<GetMeasureUnitByIdQuery, GetMeasureUnitDTO>
{
    private readonly IMeasureUnitService _measureUnitService;
    public GetMeasureUnitByIdQueryHandler(IMeasureUnitService measureUnitService)
    {
        _measureUnitService = measureUnitService;
    }
    public async Task<GetMeasureUnitDTO> Handle(GetMeasureUnitByIdQuery request, CancellationToken cancellationToken)
    {
        var unit = await _measureUnitService.GetByIdAsync(request.Id);
        if (unit is null)
            throw new InvalidClientOperationException("No unit of measurement was found in this ID");
        return unit;
    }
}
