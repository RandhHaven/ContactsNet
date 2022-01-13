namespace Phonebook.Contacts.Core.Repository
{
    using Phonebook.Contacts.Core.GenericRepository;
    using Phonebook.Contacts.Infrastructure.Data;
    using System;

    public interface IContactRepository : IRepository<Contacts>
    {
        Contacts Update(Guid id, Contacts entity);
    }
}
