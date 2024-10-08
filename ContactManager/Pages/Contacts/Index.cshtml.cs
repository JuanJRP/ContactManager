using ContactManager.Models;
using ContactManager.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ContactManager.Models.ContactModel;
using static ContactManager.Services.ContactServices;

namespace ContactManager.Pages.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly ContactService _contactService;

        public IndexModel(ContactService contactService)
        {
            _contactService = contactService;
        }

        public List<Contact> Contacts { get; set; }

        public async Task OnGetAsync()
        {
            Contacts = (await _contactService.GetAllContacts()).ToList();
        }
    }
}
