/****** Object:  StoredProcedure [dbo].[Users_DeleteById]    Script Date: 4/10/2024 10:44:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Isaac Diaz
-- Create date: 03/08/2024
-- Description: Delete a user from the User table based off of the Id.

-- MODIFIED BY: author
-- MODIFIED DATE:12/1/2020
-- Note:
-- =============================================

CREATE PROC [dbo].[Users_DeleteById]
	@Id int
AS
/*
	Declare @Id int = 5

	Execute dbo.Users_DeleteById @Id
*/

BEGIN

	DELETE FROM [dbo].[Users]
		  WHERE Id = @Id

END

GO
