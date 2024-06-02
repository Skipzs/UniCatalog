using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Users
{
  public class User
  {
    public string? ProgramStudiu { get; set; }

    public string? CicluInvatamant { get; set; }

    public string? AnStudiu { get; set; }

    public string? Semestru { get; set; }
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public short Age { get; set; } = 18;

    public string CNP { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

  }
}
