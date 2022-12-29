using C.Service.CQRS.Commands.MeasureUnitCommands;
using C.Service.DTOs.CustomerDTos;
using C.Service.DTOs.MeasureUnitDTOs;
using C.Service.Services.Implementations;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.MeasureUnitCommandHandlers;
public class CreateMeasureUnitCommandHandler : IRequestHandler<CreateMeasureUnitCommand, CreateMeasureUnitDTO>
{
    private readonly IMeasureUnitService _measureUnitService;
    public CreateMeasureUnitCommandHandler(IMeasureUnitService measureUnitService)
    {
        _measureUnitService = measureUnitService;
    }
    public async Task<CreateMeasureUnitDTO> Handle(CreateMeasureUnitCommand request, CancellationToken cancellationToken)
    {
        CreateMeasureUnitDTO createMeasureUnitDTO = new()
        {
            Name = request.Name,
            
        };
        await _measureUnitService.CreateAsync(createMeasureUnitDTO);
        return await Task.FromResult(createMeasureUnitDTO);
    }
}
