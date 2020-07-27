using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordsThatIKnowWebAPI.Domain
{
    public class Words
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Word { get; set; }
        public int Box { get; set; }
    }
}
