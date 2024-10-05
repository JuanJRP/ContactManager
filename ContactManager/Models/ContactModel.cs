using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ContactManager.Models
{
    public class ContactModel
    {
        public class Contact
        {
            [BsonId]
            [BsonRepresentation(BsonType.Int32)]
            public int Id { get; set; }

            [BsonElement("Name")]
            public string Name { get; set; }

            [BsonElement("Email")]
            public string Email { get; set; }

            [BsonElement("Phone")]
            public string Phone { get; set; }
        }
    }
}
