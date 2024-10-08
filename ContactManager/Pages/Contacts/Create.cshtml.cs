using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContactManager.Interfaces;
using ContactManager.Models;
using static ContactManager.Interfaces.ContactInterface;
using static ContactManager.Models.ContactModel;

namespace ContactManager.Pages.Contacts
{
    public class CreateModel : PageModel
    {
        private readonly IContactRepository _contactRepository;

        public CreateModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [BindProperty]
        public Contact Contact { get; set; }  // Asegúrate de que esta propiedad esté aquí

        public void OnGet()
        {
            Contact = new Contact(); // Inicializa el objeto Contact
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _contactRepository.CreateContact(Contact);
            return RedirectToPage("./Index");
        }
    }
}
