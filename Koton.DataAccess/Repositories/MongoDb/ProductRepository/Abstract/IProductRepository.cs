using Koton.Catalog.DataAccess.Repositories.MongoDb.GenericRepository.Abstract;
using Koton.Catalog.Entity.Entities.Concrete;

namespace Koton.Catalog.DataAccess.Repositories.MongoDb.ProductRepository.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
