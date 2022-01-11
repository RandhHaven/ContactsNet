namespace Phonebook.Contacts.Api.Mapper
{
    using AutoMapper;
    using Phonebook.Contacts.Infrastructure.Data;
    using Phonebook.Contacts.Core.Entities;
    public class ContactsMap : Profile
    {
        public ContactsMap()
        {
            CreateMap<Contacts, ContactsEntity>();
            CreateMap<ContactsEntity, Contacts>();
        }
    }
}