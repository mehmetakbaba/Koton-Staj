using Koton.Catalog.DataAccess.Repositories.MongoDb.ProductRepository.Abstract;
using Koton.Catalog.Entity.Entities.Concrete;
using MongoDB.Driver;

namespace Koton.Catalog.DataAccess.Repositories.MongoDb.ProductRepository.Concrete
{
    public class ProductRepository(IMongoDatabase database, string collectionName) : IProductRepository
    {
        private readonly IMongoCollection<Product> _collection = database.GetCollection<Product>(collectionName);

        public async Task<List<Product>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            var filter = Builders<Product>.Filter.Eq(c => c.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Product entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(string id, Product entity)
        {
            var filter = Builders<Product>.Filter.Eq(c => c.Id, id);
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<Product>.Filter.Eq(c => c.Id, id);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<List<Product>> getProductsByCategoryId(string categoryId)
        {
            var filter = Builders<Product>.Filter.Eq(c => c.CategoryId, categoryId);
            return await _collection.Find(filter).ToListAsync();
            
        }
    }

}