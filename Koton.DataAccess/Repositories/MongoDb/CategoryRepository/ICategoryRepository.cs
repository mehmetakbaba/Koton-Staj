using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.DataAccess.Repositories.MongoDb.Abstract;
using Koton.Entity.Entities.Concrete;

namespace Koton.DataAccess.Repositories.MongoDb.CategoryRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}
