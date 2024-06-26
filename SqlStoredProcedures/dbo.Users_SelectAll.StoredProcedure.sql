/****** Object:  StoredProcedure [dbo].[Users_SelectAll]    Script Date: 4/10/2024 10:44:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Isaac Diaz
-- Create date: 03/08/2024
-- Description: Select all users from the User table.

-- MODIFIED BY: author
-- MODIFIED DATE:12/1/2020
-- Note:
-- =============================================

CREATE PROC [dbo].[Users_SelectAll]

AS
/*

	EXECUTE dbo.Users_SelectAll

*/


BEGIN

	SELECT [Id]
		  ,[Email]
		  ,[FirstName]
		  ,[Mi]
		  ,[LastName]
		  ,[Password]
		  ,[StatusId]
		  ,[AvatarUrl]
		  ,[DateCreated]
		  ,[DateModified]
	  FROM [dbo].[Users]

END



GO
