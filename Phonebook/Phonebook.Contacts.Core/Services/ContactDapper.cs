namespace Phonebook.Contacts.Core.Services
{
    using Dapper;
    using global::Dapper;
    using Phonebook.Contacts.Core.Entities;
    using System;
    using System.Data;
    using System.Threading.Tasks;

    public class ContactDapper : IContactDapper
    {
        private readonly IGenericDapper _dapper;

        public ContactDapper(IGenericDapper dapper) : base()
        {
            this._dapper = dapper ?? throw new ArgumentNullException(nameof(dapper));
        }

        public async Task<ContactsEntity> GetAll()
        {
            var result = await Task.FromResult(_dapper.Get<ContactsEntity>($"Select * from [Contacts] ", null, commandType: CommandType.Text));
            return result;
        }

        public async Task<ContactsEntity> GetById(int Id)
        {
            var result = await Task.FromResult(_dapper.Get<ContactsEntity>($"Select * from [Contacts] where Id = {Id}", null, commandType: CommandType.Text));
            return result;
        }

        public Task<ContactsEntity> Create(ContactsEntity data)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("pContactId", data.ContactId, DbType.Guid);
            dbPara.Add("pFirtsName", data.FirtsName, DbType.String);
            dbPara.Add("pLastName", data.LastName, DbType.String);
            dbPara.Add("pCompany", data.Company, DbType.String);
            dbPara.Add("pEmail", data.Email, DbType.String);
            dbPara.Add("pPhoneNumber", data.PhoneNumber, DbType.String);
            var createContact = Task.FromResult(_dapper.Create<ContactsEntity>("[dbo].[SP_Create_Contact]",
                            dbPara,
                            commandType: CommandType.StoredProcedure));
            return createContact;
        }

        public Task<ContactsEntity> Update(ContactsEntity data)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("pContactId", data.ContactId, DbType.Guid);
            dbPara.Add("pFirtsName", data.FirtsName, DbType.String);
            dbPara.Add("pLastName", data.LastName, DbType.String);
            dbPara.Add("pCompany", data.Company, DbType.String);
            dbPara.Add("pEmail", data.Email, DbType.String);
            dbPara.Add("pPhoneNumber", data.PhoneNumber, DbType.String);
            var updateArticle = Task.FromResult(_dapper.Update<ContactsEntity>("[dbo].[SP_Update_Contact]",
                            dbPara,
                            commandType: CommandType.StoredProcedure));
            return updateArticle;
        }

        public async Task<ContactsEntity> Delete(int Id)
        {
            var result = await Task.FromResult(this._dapper.Detele<ContactsEntity>($"Delete [Contacts] Where Id = {Id}", null, commandType: CommandType.Text));
            return result;
        }
    }
}