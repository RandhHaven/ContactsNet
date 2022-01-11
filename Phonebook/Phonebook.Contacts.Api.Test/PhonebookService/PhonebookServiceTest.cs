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
        private IUnitOfWork uiService;
        public PhonebookServiceTest()
        {
        }

        [Fact]
        public async void GetContactById()
        {

            var mockContexto = CrearContexto();

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();

            var request = new Contacts()
            {
                ContactId = new Guid("553D1943-6FAC-42D9-7B8F-08D9C8D18BF0")
            };

            this.uiService = new UnitOfWork(mockContexto.Object);
            var contact = await this.uiService._IContactsRepository.Get(request.ContactId);
            
            Assert.NotNull(contact);
            Assert.True(contact.ContactId == Guid.Empty);
        }

        [Fact]
        public async void GetContacts()
        {
            //1. Emular a la instancia de entity framework core - ContextoLibreria
            // para emular la acciones y eventos de un objeto en un ambiente de unit test 
            //utilizamos objetos de tipo mock

            var mockContexto = CrearContexto();

            // 2 Emular al mapping IMapper

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();

            //3. Instanciar a la clase servicio

            this.uiService = new UnitOfWork(mockContexto.Object);
            var contacts = await this.uiService._IContactsRepository.GetAll();            
            Assert.True(contacts.Any());
        }

        [Fact]
        public async void SaveContacts()
        {
            System.Diagnostics.Debugger.Launch();

            var options = new DbContextOptionsBuilder<ContactsDBContext>()
                .UseInMemoryDatabase(databaseName: "BaseDatosLibro")
                .Options;

            var mockContexto = new ContactsDBContext(options);
            var request = new Contacts()
            {
                ContactId = new Guid(),
                FirtsName = "",
                LastName = "",

            };
            this.uiService = new UnitOfWork(mockContexto);
            var saveContact = await this.uiService._IContactsRepository.Add(request);
                       
            Assert.True(saveContact != null);
        }
    }
}
