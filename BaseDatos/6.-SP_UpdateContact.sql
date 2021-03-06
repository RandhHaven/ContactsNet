USE [ContactsDB]
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateContact]    Script Date: 12/1/2022 21:32:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_UpdateContact]
	-- Add the parameters for the stored procedure here
	@pContactId nvarchar(100),
	@pFirtsName nvarchar(100),
	@pLastName nvarchar(100),
	@pCompany nvarchar(100),
	@pEmail nvarchar(100),
	@pPhoneNumber nvarchar(50)
AS
BEGIN
	
    -- Update statements for procedure here
	update [dbo].[Contacts]
	set [FirtsName] = @pFirtsName,
		[LastName] = @pLastName,
		[Company] = @pCompany,
		[Email] = @pEmail,
		[PhoneNumber] = @pPhoneNumber
	where [ContactID] = @pContactId
END
