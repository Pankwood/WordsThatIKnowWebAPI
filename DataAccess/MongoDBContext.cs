using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordsThatIKnowWebAPI.DataAccess
{
    public class MongoDBContext
    {
        private IMongoDatabase db;

        public MongoDBContext(string database)
        {
            var client = new MongoClient(); 
            db = client.GetDatabase(database);
        }

        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).CountDocuments() == 0 ? null : collection.Find(new BsonDocument()).ToList();
        }
        public T GetWordByID<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);

            return collection.Find(filter).FirstOrDefault();
        }
        public void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }
    }
}
