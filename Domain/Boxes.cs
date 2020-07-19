using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordsThatIKnowWebAPI.Domain
{
    public class Boxes
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Box { get; set; }

        //TODO: Not sure if Language should be here or in another class
        public string LanguageTarget { get; set; }
        public string LanguageOrigen { get; set; }

        public List<Contents> Contents { get; set; }
    }
}
