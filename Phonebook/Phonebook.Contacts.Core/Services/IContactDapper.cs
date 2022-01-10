using Phonebook.Contacts.Core.Entities;
using System.Threading.Tasks;

namespace Phonebook.Contacts.Core.Services
{
    public interface IContactDapper
    {
        Task<ContactsEntity> Create(ContactsEntity data);
        Task<ContactsEntity> GetById(int Id);
        Task<ContactsEntity> Update(ContactsEntity data);
        Task<ContactsEntity> Delete(int Id);
    }
}