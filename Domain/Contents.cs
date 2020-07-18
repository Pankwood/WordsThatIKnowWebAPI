using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordsThatIKnowWebAPI.Controllers;

namespace WordsThatIKnowWebAPI.Domain
{
    public class Contents
    {
        [BsonId]
        public Guid Id { get; set; }
        public String Content { get; set; }
        public List<Translations> Translations { get; set; }
        public List<Curiosities> Curiosities { get; set; }
        public List<Definitions> Definitions { get; set; }
        public List<Images> Images { get; set; }
    }
}
