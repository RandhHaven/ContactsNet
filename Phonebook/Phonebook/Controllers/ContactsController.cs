namespace Phonebook.Api.Contacts.Controllers
{
    using System;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Phonebook.Api.Contacts.Shared;
    using Phonebook.Contacts.Core.Entities;
    using Phonebook.Contacts.Core.GenericRepository;
    using Phonebook.Contacts.Infrastructure.Data;
    using System.Threading.Tasks;
    using Phonebook.Contacts.Core.Services;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/[controller]")]
    [ApiController]
    public sealed class ContactsController : GenericController<IUnitOfWork>
    {
        private readonly IMapper _mapper;
        private readonly IContactDapper _IContactDapper;

        #region Builds
        public ContactsController(IUnitOfWork uiService, IMapper mapper, IContactDapper iContactDapper) : base(uiService)
        {
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._IContactDapper = iContactDapper ?? throw new ArgumentNullException(nameof(iContactDapper));
        }
        #endregion    

        // GET: api/Contacts
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var listContacts = await this.UIService._IContactsRepository.GetAll();
            return Ok(_mapper.Map<List<Contacts>, List<ContactsEntity>>(listContacts.ToList()));
            //var contacts = await _IContactDapper.GetAll();
            //return contacts;
        }

        // GET: api/Contacts/id
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ContactsEntity>> GetFilter(Guid id)
        {
            var contact = await this.UIService._IContactsRepository.Get(id);
            return Ok(_mapper.Map<Contacts, ContactsEntity>(contact));
        }

        // POST: api/Contacts
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] ContactsEntity request)
        {
            if (ModelState.IsValid && !Object.Equals(request, null))
            {
                var contacts = await this.UIService._IContactsRepository.Add(_mapper.Map<ContactsEntity, Contacts>(request));
                this.UIService.Commit();
                return Ok(_mapper.Map<Contacts, ContactsEntity>(contacts));
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Contacts/id
        [HttpPut("{id}")]
        public IActionResult UpdateContact(Guid id, [FromBody] ContactsEntity request)
        {
            if (ModelState.IsValid && !Object.Equals(request, null))
            {
                var contact = this.UIService._IContactsRepository.Update(id, _mapper.Map<ContactsEntity, Contacts>(request));
                return Ok(request);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Contacts/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            var removeEntity = await this.UIService._IContactsRepository.Remove(id);
            this.UIService.Commit();
            return Ok(_mapper.Map<ContactsEntity>(removeEntity));
        }
    }
}
