using B.Repository.Repositories.Interfaces;
using Dapper;
using Domain.Entities;
using Microsoft.Data.SqlClient;

namespace B.Repository.Repositories.Implementations;
public class MeasureUnitRepository : BaseSqlRepository, IMeasureUnitRepository
{
    public Task CreateAsync(MeasureUnit entity)
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();

            connection.Execute(@"INSERT INTO [dbo].[MeasureUnits] ([Name],[SoftDelete])VALUES (@Name,0)",new { entity.Name });
        });
    }

    public Task DeleteAsync(int id)
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();

            connection.Execute(@$"UPDATE MeasureUnits SET SoftDelete = 1 WHERE Id = {id}");
        });        
    }

    public Task<List<MeasureUnit>> GetAllAsync()
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();

            return connection.Query<MeasureUnit>(@"SELECT * FROM [dbo].[MeasureUnits] WHERE SoftDelete = 0 ORDER BY Id DESC").ToList();
        });
    }

    public Task<MeasureUnit> GetAsync(int id)
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();

            return connection.QueryFirstOrDefault<MeasureUnit>(@$"SELECT * FROM MeasureUnits WHERE Id = {id} AND SoftDelete = 0");
        });                  
    }

    public Task UpdateAsync(int id, MeasureUnit entity)
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();

            connection.Execute(@"UPDATE MeasureUnits SET Name = @Name WHERE Id = @id", new { entity.Name, id });
        });
    }
}
