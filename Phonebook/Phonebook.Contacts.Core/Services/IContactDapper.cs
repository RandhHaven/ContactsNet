namespace Phonebook.Contacts.Core.Services
{
    using Phonebook.Contacts.Core.Entities;
    using System.Threading.Tasks;

    public interface IContactDapper
    {
        Task<ContactsEntity> Create(ContactsEntity data);
        Task<ContactsEntity> GetById(int Id);
        Task<ContactsEntity> GetAll();
        Task<ContactsEntity> Update(ContactsEntity data);
        Task<ContactsEntity> Delete(int Id);
    }
}