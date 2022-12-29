using C.Service.CQRS.Queries.MeasureUnitQueries;
using C.Service.DTOs.MeasureUnitDTOs;
using C.Service.Services.Implementations;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.MeasureUnitQueryHandlers;
public class GetAllMeasureUnitsQueryHandler : IRequestHandler<GetAllMeasureUnitsQuery, List<GetMeasureUnitDTO>>
{
    private readonly IMeasureUnitService _measureUnitService;
    public GetAllMeasureUnitsQueryHandler(IMeasureUnitService measureUnitService)
    {
        _measureUnitService = measureUnitService;
    }
    public async Task<List<GetMeasureUnitDTO>> Handle(GetAllMeasureUnitsQuery request, CancellationToken cancellationToken)
    {
        return await _measureUnitService.GetAllAsync();
    }
}
