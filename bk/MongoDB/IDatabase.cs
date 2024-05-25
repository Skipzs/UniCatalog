using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB
{
    public interface IDatabase
    {
        public IMongoDatabase? Db { get; set; }
        public IMongoCollection<T> GetDbCollection<T>(string name);
    }
}
