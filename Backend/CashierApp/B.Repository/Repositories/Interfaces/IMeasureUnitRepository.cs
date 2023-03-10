using Domain.Entities;

namespace B.Repository.Repositories.Interfaces;
public interface IMeasureUnitRepository:IRepository<MeasureUnit>
{
    Task UpdateAsync(int id, MeasureUnit entity);
}
