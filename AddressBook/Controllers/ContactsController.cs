using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;
using AddressBook.Repository;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsRepository _repository;

        public ContactsController(ContactsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> Get()
        {
           return  _repository.AllContacts().ToList();
        }


        [HttpPost]
        [ProducesResponseType(400)]
        [Route("add")]
        public async Task<ActionResult<Contact>> AddContact([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            contact.Id = _repository.AllContacts().Count()+1;
            _repository.AddContact(contact);

            return CreatedAtAction(nameof(Get), _repository.AllContacts());
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [Route("update")]
        public async Task<ActionResult<bool>> UpdateContact([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.UpdateContact(contact);

            return CreatedAtAction(nameof(Get), _repository.AllContacts());
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [Route("delete")]
        public async Task<ActionResult<bool>> DeleteContact([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.DeleteContact(contact);

            return CreatedAtAction(nameof(Get), _repository.AllContacts());
        }
    }
}