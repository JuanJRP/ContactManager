using MongoDB.Driver;
using static ContactManager.Interfaces.ContactInterface;
using static ContactManager.Models.ContactModel;

namespace ContactManager.Repositories
{
    public class ContactRepositories
    {
        public class ContactRepository : IContactRepository
        {
            private readonly IMongoCollection<Contact> _contacts;

            public ContactRepository(IMongoDatabase database)
            {
                _contacts = database.GetCollection<Contact>("Contacts");
            }

            public async Task<IEnumerable<Contact>> GetContacts()
            {
                return await _contacts.Find(contact => true).ToListAsync();
            }

            public async Task<Contact> GetContactById(Int32 id)
            {
                return await _contacts.Find(contact => contact.Id == id).FirstOrDefaultAsync();
            }

            public async Task CreateContact(Contact contact)
            {
                await _contacts.InsertOneAsync(contact);
            }

            public async Task UpdateContact(Int32 id, Contact contact)
            {
                await _contacts.ReplaceOneAsync(c => c.Id == id, contact);
            }

            public async Task DeleteContact(Int32 id)
            {
                await _contacts.DeleteOneAsync(contact => contact.Id == id);
            }
        }
    }
}
