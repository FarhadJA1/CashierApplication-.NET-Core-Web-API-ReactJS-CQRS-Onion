using C.Service.CQRS.Commands.MeasureUnitCommands;
using C.Service.Services.Implementations;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.MeasureUnitCommandHandlers;
public class UpdateMeasureUnitCommandHandler : IRequestHandler<UpdateMeasureUnitCommand, bool>
{
    private readonly IMeasureUnitService _measureUnitService;
    public UpdateMeasureUnitCommandHandler(IMeasureUnitService measureUnitService)
    {
        _measureUnitService = measureUnitService;
    }
    public async Task<bool> Handle(UpdateMeasureUnitCommand request, CancellationToken cancellationToken)
    {
        await _measureUnitService.UpdateAsync(request.Id, request.UpdateDTO);
        return true;
    }
}
