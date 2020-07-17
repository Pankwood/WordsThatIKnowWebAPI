using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordsThatIKnowWebAPI.Domain
{
    public class Contents
    {
        [BsonId]
        public Guid Id { get; set; }
        public String Content { get; set; }
    }
}
