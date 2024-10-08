using MongoDB.Bson;
using static ContactManager.Models.ContactModel;

namespace ContactManager.Interfaces
{
    public class ContactInterface
    {
        public interface IContactRepository
        {
            Task<IEnumerable<Contact>> GetContacts();
            Task<Contact> GetContactById(ObjectId id);
            Task CreateContact(Contact contact);
            Task UpdateContact(ObjectId id, Contact contact);
            Task DeleteContact(ObjectId id);
        }
    }
}
