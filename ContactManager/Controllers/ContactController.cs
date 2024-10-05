﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ContactManager.Models.ContactModel;
using static ContactManager.Services.ContactServices;

namespace ContactManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactService _contactService;

        public ContactController(ContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public Task<IEnumerable<Contact>> Get()
        {
            return _contactService.GetAllContacts();
        }

        [HttpGet("{id}")]
        public Task<Contact> Get(Int32 id)
        {
            return _contactService.GetContactById(id);
        }

        [HttpPost]
        public Task Post([FromBody] Contact contact)
        {
            return _contactService.CreateContact(contact);
        }

        [HttpPut("{id}")]
        public Task Put(Int32 id, [FromBody] Contact contact)
        {
            return _contactService.UpdateContact(id, contact);
        }

        [HttpDelete("{id}")]
        public Task Delete(Int32 id)
        {
            return _contactService.DeleteContact(id);
        }
    }
}