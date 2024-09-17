using Koton.Catalog.Entity.Entities.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Koton.Catalog.Entity.Entities.Concrete;

public class ProductImage : IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public List<string> ProductImageUrl { get; set; }
        public string ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }

