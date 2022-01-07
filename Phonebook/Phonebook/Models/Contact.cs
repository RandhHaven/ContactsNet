namespace Phonebook.Api.Contacts.Models
{
    #region Directives
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    #endregion

    #region Table
    [Table("Contact")]
    [DataContract]
    public class Contact
    {
        [Key]
        [DataMember]
        public Guid? ContactID { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Field Name is Required.")]
        [StringLength(100)]
        public String FirtsName { get; set; }

        [DataMember]
        [Required]
        [StringLength(100)]
        public String LastName { get; set; }

        [DataMember]
        [StringLength(200)]
        public String Company { get; set; }

        [DataMember]
        [StringLength(200)]
        public DateTime? Email { get; set; }

        [DataMember]
        [StringLength(50)]
        public String PhoneNumber { get; set; }
    }
    #endregion
}