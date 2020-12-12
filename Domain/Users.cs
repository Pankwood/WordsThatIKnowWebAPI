using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WordsThatIKnowWebAPI.Domain
{
    public class Users
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
