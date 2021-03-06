USE [ContactsDB]
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteContact]    Script Date: 12/1/2022 21:31:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Randhall Rangel
-- Create date: <Create Date,,>
-- Description:	Delete Contact by ContactId 
-- =============================================
CREATE PROCEDURE [dbo].[SP_DeleteContact]
	-- Add the parameters for the stored procedure here
	@pContactId nvarchar(100)
AS
BEGIN
	
    -- Delete statements for procedure here
	delete from [dbo].[Contacts] where [ContactID] = @pContactId
END
