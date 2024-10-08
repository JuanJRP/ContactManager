using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ContactManager.Models
{
    public class ContactModel
    {
        public class Contact
        {
            [BsonId] 
            public ObjectId Id { get; set; } = ObjectId.GenerateNewId(); 

            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
        }
    }
}
