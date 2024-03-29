/****** Object:  StoredProcedure [dbo].[User_SelectById]    Script Date: 3/7/2024 11:35:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[User_SelectById]
	@Id int

as
/*
	Declare @Id int = 1

	Execute dbo.User_SelectById @Id

*/

Begin

SELECT [Id]
      ,[FirstName]
      ,[LastName]
      ,[DateCreated]
      ,[DateModified]
  FROM [dbo].[User]

  Where Id = @Id

End

GO
