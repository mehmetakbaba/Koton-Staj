using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Koton.Order.Domain.Entities.Concrete;

namespace Koton.Order.Aplication.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task<List<OrderDetail>> GetByUserIdAsync(string userId); // Eğer bu metod varsa kaldırabilirsiniz
    }
}