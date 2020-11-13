using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ZeroSys.Model
{
    public class User
    {

        [BsonId]
        public string ID { get; set; }
        public string Name { get; set; }
        public List<string> Permissions { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
