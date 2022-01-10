namespace Phonebook.Contacts.Core.Repository
{
    using Phonebook.Contacts.Core.GenericRepository;
    using Phonebook.Contacts.Infrastructure.Data;

    public interface IContactRepository : IRepository<Contacts>
    {
        Contacts Update(Contacts entity);
    }
}
