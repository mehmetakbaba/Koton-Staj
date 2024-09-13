using MongoDB.Driver;
using Koton.DataAccess.Repositories.MongoDb.Abstract;
using Koton.DataAccess.Repositories.MongoDb.CategoryRepository;
using Koton.Entity.Entities.Concrete;

namespace Koton.DataAccess.Repositories.MongoDb.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> _collection;

        public CategoryRepository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<Category>(collectionName);
        }

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