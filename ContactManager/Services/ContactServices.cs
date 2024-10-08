using MongoDB.Bson;
using static ContactManager.Interfaces.ContactInterface;
using static ContactManager.Models.ContactModel;

namespace ContactManager.Services
{
    public class ContactServices
    {
        public class ContactService
        {
            private readonly IContactRepository _contactRepository;

            public ContactService(IContactRepository contactRepository)
            {
                _contactRepository = contactRepository;
            }

            public Task<IEnumerable<Contact>> GetAllContacts()
            {
                return _contactRepository.GetContacts();
            }

            public Task<Contact> GetContactById(ObjectId id)
            {
                return _contactRepository.GetContactById(id);
            }

            public Task CreateContact(Contact contact)
            {
                return _contactRepository.CreateContact(contact);
            }

            public Task UpdateContact(ObjectId id, Contact contact)
            {
                return _contactRepository.UpdateContact(id, contact);
            }

            public Task DeleteContact(ObjectId id)
            {
                return _contactRepository.DeleteContact(id);
            }
        }
    }
}
