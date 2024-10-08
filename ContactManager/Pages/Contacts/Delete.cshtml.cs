using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContactManager.Interfaces;
using ContactManager.Models;
using MongoDB.Bson;
using static ContactManager.Interfaces.ContactInterface;
using static ContactManager.Models.ContactModel;

namespace ContactManager.Pages.Contacts
{
    public class DeleteModel : PageModel
    {
        private readonly IContactRepository _contactRepository;

        public DeleteModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [BindProperty]
        public Contact Contact { get; set; }  // Aseg�rate de que este sea un objeto Contact

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
            if (Contact != null)
            {
                await _contactRepository.DeleteContact(Contact.Id);
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
