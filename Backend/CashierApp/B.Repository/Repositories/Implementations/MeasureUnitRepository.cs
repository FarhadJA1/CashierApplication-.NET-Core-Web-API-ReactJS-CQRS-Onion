using B.Repository.Data;
using B.Repository.Repositories.Interfaces;
using Dapper;
using Domain.Entities;

namespace B.Repository.Repositories.Implementations;
public class MeasureUnitRepository : IMeasureUnitRepository
{
    public Task CreateAsync(MeasureUnit entity)
    {
        AppDbContext.OpenConnection();
        AppDbContext.sqlConnection.Query<MeasureUnit>(@"INSERT INTO [dbo].[MeasureUnits] ([Name])
                                                     VALUES (@Name)"
                                                     , new { entity.Name});
        AppDbContext.CloseConnection();
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        AppDbContext.OpenConnection();
        AppDbContext.sqlConnection.Query<MeasureUnit>(@$"DELETE FROM MeasureUnits
                                                         WHERE Id = {id}")
                                                      .FirstOrDefault();
        AppDbContext.CloseConnection();
        return Task.CompletedTask;
    }

    public Task<List<MeasureUnit>> GetAllAsync()
    {
        AppDbContext.OpenConnection();
        List<MeasureUnit> measureUnits = AppDbContext.sqlConnection.Query<MeasureUnit>(@"SELECT * FROM [dbo].[MeasureUnits]").ToList();
        AppDbContext.CloseConnection();
        return Task.FromResult(measureUnits);
    }

    public Task<MeasureUnit> GetAsync(int id)
    {
        AppDbContext.OpenConnection();
        MeasureUnit? measureUnit = AppDbContext.sqlConnection.Query<MeasureUnit>(@$"SELECT * FROM MeasureUnits
                                                                                    WHERE Id = {id}")
                                                                                    .FirstOrDefault();
        AppDbContext.CloseConnection();

        if (measureUnit != null)
        {
            return Task.FromResult(measureUnit);
        }
        else
        {
            throw new NullReferenceException("Measure Unit not found!");
        }
    }

    public Task UpdateAsync(int id, MeasureUnit entity)
    {
        AppDbContext.OpenConnection();
        AppDbContext.sqlConnection.Query<MeasureUnit>(@"UPDATE MeasureUnits
                                                      SET Name = @Name
                                                      WHERE Id = @id", 
                                                      new { entity.Name,id });
        AppDbContext.CloseConnection();
        return Task.CompletedTask;
    }
}
