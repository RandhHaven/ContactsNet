namespace Phonebook.Contacts.Core.GenericRepository
{
    using Phonebook.Contacts.Core.Repository;
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IContactRepository _IContactsRepository { get; set; }
    }
}
