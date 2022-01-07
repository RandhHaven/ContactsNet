namespace Phonebook.Contacts.Core.Entities
{
    using System;

    public partial class ContactsEntity
    {
        public Guid ContactId { get; set; }
        public string FirtsName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}