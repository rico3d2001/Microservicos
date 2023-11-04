using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalogo.API.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        [BsonElement("Name")] 
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
