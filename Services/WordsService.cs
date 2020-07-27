using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordsThatIKnowWebAPI.DataAccess;
using WordsThatIKnowWebAPI.Domain;

namespace WordsThatIKnowWebAPI.Services
{
    public class WordsService
    {
        private IConfiguration configuration;
        private MongoDBContext db;
        public WordsService(IConfiguration iConfig)
        {
            configuration = iConfig;
            db = new MongoDBContext(configuration.GetSection("ContentsDatabaseSettings").GetSection("DatabaseName").Value);
        }
        public List<T> GetCollections<T>(string value)
        {
            return db.GetCollections<T>(value);
        }

        public void InsertCollections(string value, List<Words> collection)
        {
            db.InsertCollections(value, collection);
        }
    }
}
