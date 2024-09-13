using Koton.DataAccess.Repositories.MongoDb.Concrete;
using Koton.Entity.Entities.Concrete;
using MongoDB.Driver;

namespace Koton.DataAccess.Repositories.MongoDb.ProductRepository
{

    public class ProductRepository<IDto> : GenericRepository<IDto> where IDto : class
    {
        public ProductRepository(IMongoDatabase database, string collectionName) : base(database, collectionName)
        {
        }
    }

}