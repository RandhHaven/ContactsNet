namespace Phonebook.Contacts.Core.GenericRepository
{
    using Phonebook.Contacts.Core.Repository;
    using Phonebook.Contacts.Infrastructure.Data;
    using System;

    public sealed class UnitOfWork : IUnitOfWork
    {
        public IContactsRepository _IContactsRepository { get; set; }

        private readonly ContactsDBContext _databaseContext;

        public UnitOfWork(ContactsDBContext databaseContext)
        {
            this._databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            this._IContactsRepository = new ContactsRepository(this._databaseContext);
        }

        public void Dispose()
        {
            this._databaseContext.Dispose();
        }

        public void Commit()
        {
            this._databaseContext.SaveChanges();
        }
    }
}
