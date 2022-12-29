using C.Service.CQRS.Queries.MeasureUnitQueries;
using C.Service.DTOs.MeasureUnitDTOs;
using C.Service.Services.Implementations;
using C.Service.Services.Interfaces;
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
        return await _measureUnitService.GetByIdAsync(request.Id);
    }
}
