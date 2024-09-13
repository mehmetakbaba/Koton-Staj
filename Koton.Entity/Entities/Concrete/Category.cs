using Koton.Entity.Entities.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Koton.Entity.Entities.Concrete;

    public class Category : IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = default!;

        public String CategoryName { get; set; } = default!;
        
    }

