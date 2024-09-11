using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Koton.Catalog.Entities;

    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } = default!;

        public String CategoryName { get; set; } = default!;
    }

