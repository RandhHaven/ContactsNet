namespace Phonebook.Contacts.Api.Test.ControllerTest
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Phonebook.Contacts.Api.Test.BaseTest;
    using Phonebook.Contacts.Core.GenericRepository;
    using Phonebook.Contacts.Infrastructure.Data;
    using System;
    using System.Linq;
    using Xunit;

    public sealed class PhonebookServiceTest : BaseServiceTest
    {       
        public PhonebookServiceTest()
        {
        }

        [Fact]
        public async void GetContactById()
        {           
            var request = new Contacts()
            {
                ContactId = new Guid("00000000-0000-0000-0000-000000000000")
            };

            this.uiService = new UnitOfWork(this.dbContext);
            var contact = await this.uiService._IContactsRepository.Get(request.ContactId);
            
            Assert.NotNull(contact);
            Assert.True(contact.ContactId == Guid.Empty);
        }

        [Fact]
        public async void GetContacts()
        {
            //1. Instanciar a la clase servicio
            this.uiService = new UnitOfWork(this.dbContext);
            var contacts = await this.uiService._IContactsRepository.GetAll();
            
            //3. Assert
            Assert.True(contacts.Any());
        }

        [Fact]
        public async void SaveContacts()
        {
            System.Diagnostics.Debugger.Launch();

            var options = new DbContextOptionsBuilder<ContactsDBContext>()
                .UseInMemoryDatabase(databaseName: "ContactsDB")
                .Options;

            var mockContexto = new ContactsDBContext(options);
            var request = new Contacts()
            {
                ContactId = Guid.NewGuid(),
                FirtsName = "FirrtsName",
                LastName = "LastName",
                Company = "New Company",
                Email = "New Email",
                PhoneNumber = "232313222"
            };
            this.uiService = new UnitOfWork(mockContexto);
            var saveContact = await this.uiService._IContactsRepository.Add(request);
                       
            Assert.True(saveContact != null);
        }
    }
}
