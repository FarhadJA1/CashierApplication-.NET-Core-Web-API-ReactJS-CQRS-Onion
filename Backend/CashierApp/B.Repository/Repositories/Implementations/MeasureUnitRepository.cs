using B.Repository.Repositories.Interfaces;
using Dapper;
using Domain.Entities;
using Microsoft.Data.SqlClient;

namespace B.Repository.Repositories.Implementations;
public class MeasureUnitRepository : BaseSqlRepository, IMeasureUnitRepository
{
    public Task CreateAsync(MeasureUnit entity)
    {
        using var connection = OpenConnection();

        connection.Query<MeasureUnit>(@"INSERT INTO [dbo].[MeasureUnits] ([Name])
                                        VALUES (@Name)",
                                        new { entity.Name});
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        using var connection = OpenConnection();

        connection.Query<MeasureUnit>(@"DELETE FROM MeasureUnits
                                        WHERE Id = @id", new { id })
                                                      .FirstOrDefault();
        return Task.CompletedTask;
    }

    public Task<List<MeasureUnit>> GetAllAsync()
    {
        using var connection = OpenConnection();

        List<MeasureUnit> measureUnits = connection.Query<MeasureUnit>(@"SELECT * FROM [dbo].[MeasureUnits]").ToList();
        return Task.FromResult(measureUnits);
    }

    public Task<MeasureUnit> GetAsync(int id)
    {
        using var connection = OpenConnection();

        MeasureUnit? measureUnit = connection.Query<MeasureUnit>(@"SELECT * FROM MeasureUnits
                                                                   WHERE Id = @id", new { id })
                                                                   .FirstOrDefault();
        

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
        using var connection = OpenConnection();

        connection.Query<MeasureUnit>(@"UPDATE MeasureUnits
                                        SET Name = @Name
                                        WHERE Id = @id", 
                                        new { entity.Name,id });        
        return Task.CompletedTask;
    }
}
