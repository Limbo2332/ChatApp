using MongoDB.Bson.Serialization.Attributes;

namespace ChatApp.DAL.Entities
{
    public class Image
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("image"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string ImagePath { get; set; } = string.Empty;
    }
}
