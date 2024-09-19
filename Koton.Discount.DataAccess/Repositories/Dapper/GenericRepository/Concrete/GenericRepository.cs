using System.Data;
using Dapper;
using Koton.Discount.DataAccess.Repositories.Dapper.GenericRepository.Abstract;

namespace Koton.Discount.DataAccess.Repositories.Dapper.GenericRepository.Concrete;

public class GenericRepository<T>(IDbConnection dbConnection) : IGenericRepository<T>
    where T : class
{
    public async Task<List<T>> GetAllAsync()
    {
        var query = $"SELECT * FROM {typeof(T).Name}";
        var result = await dbConnection.QueryAsync<T>(query);
        return result.AsList();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var query = $"SELECT * FROM {typeof(T).Name} WHERE Id = @Id";
        var result = await dbConnection.QuerySingleOrDefaultAsync<T>(query, new { Id = id });
        return result;
    }

    public async Task AddAsync(T entity)
    {
        var query = $@"INSERT INTO {typeof(T).Name} ({GetColumns()}) 
                       VALUES ({GetParameters()})";
        await dbConnection.ExecuteAsync(query, entity);
    }

    public async Task UpdateAsync(int id, T entity)
    {
        var query = $@"UPDATE {typeof(T).Name} 
                       SET {GetUpdateColumns()} 
                       WHERE Id = @Id";
        await dbConnection.ExecuteAsync(query, new { Id = id, entity });
    }

    public async Task DeleteAsync(int id)
    {
        var query = $"DELETE FROM {typeof(T).Name} WHERE Id = @Id";
        await dbConnection.ExecuteAsync(query, new { Id = id });
    }

    private string GetColumns()
    {
        
        var properties = typeof(T).GetProperties();
        var columns = string.Join(", ", properties.Select(p => p.Name));
        return columns;
    }

    private string GetParameters()
    {
        
        var properties = typeof(T).GetProperties();
        var parameters = string.Join(", ", properties.Select(p => "@" + p.Name));
        return parameters;
    }

    private string GetUpdateColumns()
    {
        
        var properties = typeof(T).GetProperties();
        var columns = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));
        return columns;
    }
}