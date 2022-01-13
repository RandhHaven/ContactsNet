use [ContactsDB]
CREATE TABLE [Contacts] (
    ContactID Uniqueidentifier NOT NULL,
    FirtsName varchar(100) NOT NULL,
    LastName varchar(100),
    Company varchar(100),
	Email varchar(100),
	PhoneNumber varchar(50),
    PRIMARY KEY (ContactID)
);