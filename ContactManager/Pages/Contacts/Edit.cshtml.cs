using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContactManager.Interfaces;
using ContactManager.Models;
using MongoDB.Bson;
using static ContactManager.Interfaces.ContactInterface;
using static ContactManager.Models.ContactModel;

namespace ContactManager.Pages.Contacts
{
    public class EditModel : PageModel
    {
        private readonly IContactRepository _contactRepository;

        public EditModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [BindProperty]
        public Contact Contact { get; set; }  // Asegúrate de que esta propiedad esté presente

        public async Task<IActionResult> OnGetAsync(ObjectId id)
        {
            Contact = await _contactRepository.GetContactById(id);

            if (Contact == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Contact == null)
            {
                return Page();
            }

            await _contactRepository.UpdateContact(Contact.Id, Contact);
            return RedirectToPage("./Index");
        }
    }
}
