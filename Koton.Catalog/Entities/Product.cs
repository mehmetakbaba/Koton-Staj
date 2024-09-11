using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Koton.Catalog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; } = default!;
        public string ProductName { get; set; } = default!;
        public decimal ProductPrice { get; set; }
        public decimal ProductQuantity { get; set; }
        public TYPE Type { get; set; }
    }
}
