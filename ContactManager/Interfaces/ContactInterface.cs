using static ContactManager.Models.ContactModel;

namespace ContactManager.Interfaces
{
    public class ContactInterface
    {
        public interface IContactRepository
        {
            Task<IEnumerable<Contact>> GetContacts();
            Task<Contact> GetContactById(Int32 id);
            Task CreateContact(Contact contact);
            Task UpdateContact(Int32 id, Contact contact);
            Task DeleteContact(Int32 id);
        }
    }
}
