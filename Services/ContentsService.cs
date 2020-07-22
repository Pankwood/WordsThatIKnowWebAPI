using WordsThatIKnowWebAPI.DataAccess;
using Microsoft.Extensions.Configuration;
using System;
using WordsThatIKnowWebAPI.Domain;
using System.Collections.Generic;

namespace WordsThatIKnowWebAPI.Services
{
    public class ContentsService 
    {
        private IConfiguration configuration;
        private MongoDBContext db;
        public ContentsService(IConfiguration iConfig)
        {
            configuration = iConfig;
            db = new MongoDBContext(configuration.GetSection("ContentsDatabaseSettings").GetSection("DatabaseName").Value);
        }

        public List<T> GetCollections<T>(string value)
        {
            return db.GetCollections<T>(value);
        }

        public T GetCollectionsByID<T>(string value, Guid id)
        {
            return db.GetCollectionsByID<T>(value, id);
        }

        public void InsertCollection(string value, Boxes collection)
        {
            db.InsertCollection(value, collection);
        }
    }
}
