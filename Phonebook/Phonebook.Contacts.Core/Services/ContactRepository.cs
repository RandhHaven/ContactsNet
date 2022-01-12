namespace Phonebook.Contacts.Core.Repository
{
    using Phonebook.Contacts.GenericRepository;
    using Phonebook.Contacts.Infrastructure.Data;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class ContactRepository : Repository<Contacts>, IContactRepository
    {
        private readonly ContactsDBContext _databaseContext;

        public ContactRepository(ContactsDBContext databaseContext) : base(databaseContext)
        {
            this._databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        public override Contacts Update(Contacts entity)
        {
            var update = _databaseContext.Contacts.FirstOrDefault(obj => obj.ContactId == entity.ContactId);            
            update.FirtsName = entity.FirtsName;
            update.LastName = entity.LastName;
            update.Email = entity.Email;
            update.PhoneNumber = entity.PhoneNumber;
            update.Company = entity.Company;
            var cer = this._databaseContext.SaveChangesAsync();
            return update;
        }

        public override Task<Contacts> Add(Contacts entity)
        {
            entity.ContactId = Guid.NewGuid();
            return base.Add(entity);
        }
    }
}