namespace Phonebook.Contacts.Core.Repository
{
    using Phonebook.Contacts.Core.GenericRepository;
    using Phonebook.Contacts.Infrastructure.Data;

    public interface IContactsRepository : IRepository<Infrastructure.Data.Contacts>
    {
        Contacts Update(Infrastructure.Data.Contacts entity);
    }
}
