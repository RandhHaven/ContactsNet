namespace Phonebook.Contacts.Api.Test
{
    using AutoMapper;
    using Phonebook.Contacts.Core.Entities;
    using Phonebook.Contacts.Infrastructure.Data;

    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<Contacts, ContactsEntity>();
        }
    }
}