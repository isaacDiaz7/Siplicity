/****** Object:  StoredProcedure [dbo].[User_SelectAll]    Script Date: 3/7/2024 11:35:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[User_SelectAll]

as
/*

	Execute dbo.User_SelectAll

*/


Begin

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
	  FROM [dbo].[User]

End



GO
