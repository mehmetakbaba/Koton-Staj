using Koton.Catalog.DataAccess.Repositories.MongoDb.ProductImageRepository.Abstract;
using Koton.Catalog.Entity.Entities.Concrete;
using MongoDB.Driver;

namespace Koton.Catalog.DataAccess.Repositories.MongoDb.ProductImageRepository.Concrete
{
    public class ProductImageRepository(IMongoDatabase database, string collectionName) : IProductImageRepository
    {
        private readonly IMongoCollection<ProductImage> _collection = database.GetCollection<ProductImage>(collectionName);
        public async Task<List<ProductImage>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<ProductImage> GetByIdAsync(string id)
        {
            var filter = Builders<ProductImage>.Filter.Eq(c => c.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddAsync(ProductImage entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(string id, ProductImage entity)
        {
            var filter = Builders<ProductImage>.Filter.Eq(c => c.Id, id);
            await _collection.ReplaceOneAsync(filter,entity);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<ProductImage>.Filter.Eq(c => c.Id, id);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
