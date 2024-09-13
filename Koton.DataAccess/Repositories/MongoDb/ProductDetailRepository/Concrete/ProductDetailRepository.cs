
using Koton.DataAccess.Repositories.MongoDb.ProductDetailRepository.Abstract;
using Koton.Entity.Entities.Concrete;
using MongoDB.Driver;

namespace Koton.DataAccess.Repositories.MongoDb.ProductDetailRepository.Concrete
{
    public class ProductDetailRepository(IMongoDatabase database, string collectionName) : IProductDetailRepository
    {
        private readonly IMongoCollection<ProductDetail> _collection = database.GetCollection<ProductDetail>(collectionName);
        public async Task<List<ProductDetail>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<ProductDetail> GetByIdAsync(string id)
        {
            var filter = Builders<ProductDetail>.Filter.Eq(c => c.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddAsync(ProductDetail entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(string id, ProductDetail entity)
        {
            var filter = Builders<ProductDetail>.Filter.Eq(c => c.Id, id);
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<ProductDetail>.Filter.Eq(c => c.Id, id);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
