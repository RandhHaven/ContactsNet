namespace Phonebook.Contacts.Api.Test.BaseTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GenFu;
    using Microsoft.EntityFrameworkCore;
    using Phonebook.Contacts.Core.GenericRepository;
    using Phonebook.Contacts.Infrastructure.Data;

    public class BaseServiceTest
    {
        protected IUnitOfWork uiService;
        protected ContactsDBContext dbContext;

        public BaseServiceTest()
        {
            this.dbContext = CreateDBContext();
        }

        private IEnumerable<Contacts> GetDataTest()
        {
            A.Configure<Contacts>()
                .Fill(x => x.FirtsName).AsFirstName()
                .Fill(x => x.LastName).AsLastName()
                .Fill(x => x.Company).AsCity()
                .Fill(x => x.Email).AsEmailAddress()
                .Fill(x => x.PhoneNumber).AsPhoneNumber()
                .Fill(x => x.ContactId, () => { return Guid.NewGuid(); });

            var lista = A.ListOf<Contacts>(10);
            lista[0].ContactId = Guid.Empty;

            return lista;
        }

        protected ContactsDBContext CreateDBContext()
        {
            var options = new DbContextOptionsBuilder<ContactsDBContext>()
                 .UseInMemoryDatabase(databaseName: "ContactsDB")
                 .Options;

            var mockContexto = new ContactsDBContext(options);

            var data = this.GetDataTest().AsQueryable();
            if (!mockContexto.Contacts.Any())
            {
                foreach (var item in data)
                {
                    mockContexto.Add(new Contacts
                    {
                        ContactId = item.ContactId,
                        FirtsName = item.FirtsName,
                        LastName = item.LastName,
                        Company = item.Company,
                        Email = item.Email,
                        PhoneNumber = item.PhoneNumber
                    });
                }
            }
            
            mockContexto.SaveChanges();

            return mockContexto;
        }       
    }
}