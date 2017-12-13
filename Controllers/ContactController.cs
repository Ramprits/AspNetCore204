using System;
using System.Threading.Tasks;
using AspNetCoreApplication.Model;
using AspNetCoreApplication.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetCoreApplication.Controllers {

    [Route ("api/contact")]
    public class ContactController : Controller {
        private readonly IContactRepository _repository;
        private readonly ILogger<ContactController> _logger;

        public ContactController (IContactRepository repository, ILogger<ContactController> logger) {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetContactAsync () {
            var getContactAsync = await _repository.ContactsAsync ();
            return Ok (getContactAsync);
        }

        [HttpGet ("{contactId}", Name = "GetContact")]
        public async Task<IActionResult> GetContactAsync (Guid contactId) {
            var getContactAsync = await _repository.ContactsAsync (contactId);
            return Ok (getContactAsync);
        }

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] Contact contact) {
            if (!ModelState.IsValid) {
                return BadRequest ("Contact model state is not valid means form not valid");
            }
            await _repository.InsertContactAsync (contact);
            if (!await _repository.SaveContactAsync ()) {
                return BadRequest ($"Unable to create new contact please check mandatory fields");
            }
            var getNewContactId = await _repository.ContactsAsync (contact.ContactId);
            return Created ("GetContact", new { contactId = getNewContactId });
        }
    }
}