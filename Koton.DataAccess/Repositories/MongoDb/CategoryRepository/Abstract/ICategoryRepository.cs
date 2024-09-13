using Koton.DataAccess.Repositories.MongoDb.GenericRepository.Abstract;
using Koton.Entity.Entities.Concrete;

namespace Koton.DataAccess.Repositories.MongoDb.CategoryRepository.Abstract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}
