namespace Phonebook.Contacts.Core.Repository
{
    using Phonebook.Contacts.GenericRepository;
    using Phonebook.Contacts.Infrastructure.Data;
    using System;

    public class ContactsRepository : Repository<Contacts>, IContactsRepository
    {
        private readonly ContactsDBContext _databaseContext;

        public ContactsRepository(ContactsDBContext databaseContext) : base(databaseContext)
        {
            this._databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        public override Contacts Update(Contacts entity)
        {
            return base.Update(entity);
        }
    }
}
