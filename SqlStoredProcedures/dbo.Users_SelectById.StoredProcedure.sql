/****** Object:  StoredProcedure [dbo].[Users_SelectById]    Script Date: 4/10/2024 10:44:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Isaac Diaz
-- Create date: 03/08/2024
-- Description: Select a user based of their Id.

-- MODIFIED BY: author
-- MODIFIED DATE:12/1/2020
-- Note:
-- =============================================

CREATE PROC [dbo].[Users_SelectById]
	@Id int

AS
/*
	DECLARE @Id int = 1

	EXECUTE dbo.Users_SelectById @Id

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

  WHERE Id = @Id

END

GO
