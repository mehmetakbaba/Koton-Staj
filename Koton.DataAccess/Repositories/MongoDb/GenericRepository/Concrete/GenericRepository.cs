using Koton.Catalog.DataAccess.Repositories.MongoDb.GenericRepository.Abstract;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Koton.Catalog.DataAccess.Repositories.MongoDb.GenericRepository.Concrete
{
    internal class GenericRepository<T>(IMongoDatabase database, string collectionName) : IGenericRepository<T>
        where T : class
    {
        private readonly IMongoCollection<T> _collection = database.GetCollection<T>(collectionName);

        public async Task<List<T>> GetAllAsync() => await _collection.Find(new BsonDocument()).ToListAsync();

        public async Task<T> GetByIdAsync(string id) =>
            await _collection.Find(Builders<T>.Filter.Eq("_id", new ObjectId(id))).FirstOrDefaultAsync();

        public async Task AddAsync(T entity) => await _collection.InsertOneAsync(entity);

        public async Task UpdateAsync(string id, T entity) =>
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", new ObjectId(id)), entity);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", new ObjectId(id)));
    }
}
