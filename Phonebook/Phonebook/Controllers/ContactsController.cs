namespace Phonebook.Api.Contacts.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Phonebook.Api.Contacts.Services.Contacts;
    using Phonebook.Api.Contacts.Shared;

    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : GenericController<IContactService>
    {
        protected ContactsController(IContactService uiService) : base(uiService)
        {
        }
    }
}
