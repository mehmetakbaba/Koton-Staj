namespace Koton.DataAccess.Repositories.MongoDb.Abstract
{
    public interface IGenericRepository<T>  where T : class
    {
        
            Task<List<T>> GetAllAsync();
            Task<T> GetByIdAsync(string id);
            Task AddAsync(T entity);
            Task UpdateAsync(string id, T entity);
            Task DeleteAsync(string id);
        
    }
}
