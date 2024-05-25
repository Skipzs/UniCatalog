using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProgramStudiu
{
  public class ProgramStudiu
  {
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; } 
    public string Name { get; set; } = string.Empty;
     
    public List<string> AnStudii { get; set; } = new List<string>();
  }
}
