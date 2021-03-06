USE [ContactsDB]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetContacts]    Script Date: 12/1/2022 21:31:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Randhall Rangel
-- Create date: <Create Date,,>
-- Description:	Get Contacts List
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetContacts]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ContactID]
      ,[FirtsName]
      ,[LastName]
      ,[Company]
      ,[Email]
      ,[PhoneNumber]
    FROM [ContactsDB].[dbo].[Contacts]
END
