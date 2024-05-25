using Domain.CicluInvatamant;
using Domain.Disciplina;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB
{
    public class DataBase : IDatabase
    {
        public IMongoDatabase Db { get; set; }
        public DataBase( string Connection, string DatabaseName )
        {
            var client = new MongoClient( Connection );
            this.Db = client.GetDatabase( DatabaseName );
        }
        

        public IMongoCollection<CicluInvatamant> CicluInvatamantCollection => Db.GetCollection<CicluInvatamant>("CicluInvatamant");
        public IMongoCollection<Disciplina> DisciplinaCollection => Db.GetCollection<Disciplina>("Disciplina");
        public IMongoCollection<T> GetDbCollection<T>(string name)
        {
           return Db.GetCollection<T>(name); 
            
        }
      
    }
}
