using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Disciplina
{
    public class Disciplina
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string Id { get; set; }
        public string NumeDisciplina { get; set; }
        public int NumarCredite { get; set; }
        public string CodDisciplina { get; set; }
        public string AcronimDisciplina { get; set; }

    }
}
