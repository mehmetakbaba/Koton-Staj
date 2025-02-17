﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Catalog.DataAccess.Repositories.MongoDb.GenericRepository.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task AddAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
    }
}
