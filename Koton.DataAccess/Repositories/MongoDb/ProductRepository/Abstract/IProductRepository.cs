using Koton.DataAccess.Repositories.MongoDb.GenericRepository.Abstract;
using Koton.Entity.Entities.Concrete;

namespace Koton.DataAccess.Repositories.MongoDb.ProductRepository.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
