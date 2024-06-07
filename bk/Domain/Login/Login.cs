using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Login
{
    public class Login
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string Id { get; set; } = string.Empty;

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
