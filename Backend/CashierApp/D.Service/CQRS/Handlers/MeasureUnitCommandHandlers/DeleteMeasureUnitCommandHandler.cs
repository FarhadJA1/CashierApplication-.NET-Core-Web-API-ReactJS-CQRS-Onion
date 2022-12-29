using C.Service.CQRS.Commands.MeasureUnitCommands;
using C.Service.Services.Implementations;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.MeasureUnitCommandHandlers;
public class DeleteMeasureUnitCommandHandler : IRequestHandler<DeleteMeasureUnitCommand, bool>
{
    private readonly IMeasureUnitService _measureUnitService;
    public DeleteMeasureUnitCommandHandler(IMeasureUnitService measureUnitService)
    {
        _measureUnitService = measureUnitService;
    }
    public async Task<bool> Handle(DeleteMeasureUnitCommand request, CancellationToken cancellationToken)
    {
        await _measureUnitService.DeleteAsync(request.Id);
        return true;
    }
}
