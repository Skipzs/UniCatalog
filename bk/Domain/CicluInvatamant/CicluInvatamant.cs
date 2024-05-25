using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CicluInvatamant
{
    public class CicluInvatamant
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }

    public string Nume { get; set; }
        public List <string> ProgramStudiuIds { get; set; }
    }
}
