using C.Service.DTOs.MeasureUnitDTOs;
using MediatR;

namespace C.Service.CQRS.Queries.MeasureUnitQueries;
public class GetAllMeasureUnitsQuery : IRequest<List<GetMeasureUnitDTO>>
{

}
