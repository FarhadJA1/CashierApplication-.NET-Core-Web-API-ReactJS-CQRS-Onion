using C.Service.DTOs.MeasureUnitDTOs;
using MediatR;

namespace C.Service.CQRS.Queries.MeasureUnitQueries;

public class GetMeasureUnitByIdQuery : IRequest<GetMeasureUnitDTO>
{
    public int Id { get; set; }
}
