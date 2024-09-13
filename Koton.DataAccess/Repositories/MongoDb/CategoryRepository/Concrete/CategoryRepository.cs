using Koton.DataAccess.Repositories.MongoDb.CategoryRepository.Abstract;
using Koton.Entity.Entities.Concrete;
using MongoDB.Driver;

namespace Koton.DataAccess.Repositories.MongoDb.CategoryRepository.Concrete
{
    public class CategoryRepository(IMongoDatabase database, string collectionName) : ICategoryRepository
    {
        private readonly IMongoCollection<Category> _collection = database.GetCollection<Category>(collectionName);

        public async Task<List<Category>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Category> GetByIdAsync(string id)
        {
            var filter = Builders<Category>.Filter.Eq(c => c.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Category entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(string id, Category entity)
        {
            var filter = Builders<Category>.Filter.Eq(c => c.Id, id);
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<Category>.Filter.Eq(c => c.Id, id);
            await _collection.DeleteOneAsync(filter);
        }
    }
}