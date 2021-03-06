USE [ContactsDB]
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateContact]    Script Date: 12/1/2022 21:30:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Randhall Rangel
-- Create date: <Create Date,,>
-- Description:	Get Contacts List
-- =============================================
CREATE PROCEDURE [dbo].[SP_CreateContact]
	-- Add the parameters for the stored procedure here
	@pContactId nvarchar(100),
	@pFirtsName nvarchar(100),
	@pLastName nvarchar(100),
	@pCompany nvarchar(100),
	@pEmail nvarchar(100),
	@pPhoneNumber nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Contacts]
           ([ContactID] ,[FirtsName] ,[LastName] ,[Company] ,[Email] ,[PhoneNumber])
     VALUES
           (@pContactId, @pFirtsName, @pLastName, @pCompany, @pEmail, @pPhoneNumber);
END
