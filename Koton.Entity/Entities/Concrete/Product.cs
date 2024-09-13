using Koton.Entity.Entities.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Koton.Entity.Entities.Concrete;
    public class Product : IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = default!;
        public string ProductName { get; set; } = default!;
        public decimal ProductPrice { get; set; }
        public List<string> ProductImageUrl { get; set; }
        public decimal ProductAllQuantity { get; set; }
        public Dictionary<string,int> ProductSizeQuantity { get; set; }
        public string ProductColor { get; set; } = default!;
        public string ProductDespriction { get; set; } = default!;
        public string CategoryId { get; set; } = default!;
        [BsonIgnore]
        public Category Category { get; set; } 
    }


