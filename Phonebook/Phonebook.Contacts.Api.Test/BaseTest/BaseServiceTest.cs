namespace Phonebook.Contacts.Api.Test.BaseTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GenFu;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Phonebook.Contacts.Infrastructure.Data;

    public class BaseServiceTest
    {
        private IEnumerable<Contacts> ObtenerDataPrueba()
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

        protected Mock<ContactsDBContext> CrearContexto()
        {

            var dataPrueba = ObtenerDataPrueba().AsQueryable();

            var dbSet = new Mock<DbSet<Contacts>>();
            dbSet.As<IQueryable<Contacts>>().Setup(x => x.Provider).Returns(dataPrueba.Provider);
            dbSet.As<IQueryable<Contacts>>().Setup(x => x.Expression).Returns(dataPrueba.Expression);
            dbSet.As<IQueryable<Contacts>>().Setup(x => x.ElementType).Returns(dataPrueba.ElementType);
            dbSet.As<IQueryable<Contacts>>().Setup(x => x.GetEnumerator()).Returns(dataPrueba.GetEnumerator());

            dbSet.As<IAsyncEnumerable<Contacts>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
            .Returns(new AsyncEnumerator<Contacts>(dataPrueba.GetEnumerator()));


            dbSet.As<IQueryable<Contacts>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Contacts>(dataPrueba.Provider));


            var contexto = new Mock<ContactsDBContext>();
            contexto.Setup(x => x.Contacts).Returns(dbSet.Object);
            return contexto;
        }
    }
}