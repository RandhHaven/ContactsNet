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

    [Route("api/[controller]")]
    [ApiController]
    public sealed class ContactsController : GenericController<IUnitOfWork>
    {
        private readonly IMapper _mapper;

        #region Builds
        public ContactsController(IUnitOfWork uiService, IMapper mapper) : base(uiService)
        {
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion    

        // GET: api/Contacts
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await this.UIService._IContactsRepository.GetAll();
            return Ok(_mapper.Map<ContactsEntity>(contacts));
        }

        // POST: api/Auto
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] ContactsEntity request)
        {
            if (ModelState.IsValid && !Object.Equals(request, null))
            {
                var contacts = await UIService._IContactsRepository.Add(_mapper.Map<Contacts>(request));
                return Ok(_mapper.Map<ContactsEntity>(contacts));
            }
            return BadRequest(ModelState);
        }

        // PUT: api/UpdateContact/id
        [HttpPut("{id}")]
        public void UpdateContact(int id, [FromBody] ContactsEntity contact)
        {
            this.UIService._IContactsRepository.Update(_mapper.Map<Contacts>(contact));
        }

        // PUT: api/DeleteContact/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var removeEntity = await this.UIService._IContactsRepository.Remove(id);
            return Ok(_mapper.Map<ContactsEntity>(removeEntity));
        }
    }
}
