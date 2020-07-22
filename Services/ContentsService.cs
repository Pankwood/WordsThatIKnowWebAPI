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

        public List<T> LoadRecords<T>(string value)
        {
            return db.LoadRecords<T>(value);
        }

        public T GetRecordByID<T>(string value, Guid id)
        {
            return db.GetWordByID<T>(value, id);
        }

        public void InsertRecord(string value, Boxes collection)
        {
            db.InsertRecord(value, collection);
        }
    }
}
