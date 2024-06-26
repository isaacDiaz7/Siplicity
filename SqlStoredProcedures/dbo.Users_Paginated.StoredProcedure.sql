/****** Object:  StoredProcedure [dbo].[Users_Paginated]    Script Date: 4/10/2024 10:44:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Isaac Diaz
-- Create date: 04/10/2024
-- Description: Obtain users in a paginated format.

-- MODIFIED BY: author
-- MODIFIED DATE:12/1/2020
-- Note:
-- =============================================

CREATE PROC [dbo].[Users_Paginated]
	@PageIndex int,
	@PageSize int

AS
/*
	DECLARE @PageIndex int = 0,
			@PageSize int = 4

	EXECUTE dbo.Users_Paginated @PageIndex,
								@PageSize

*/

BEGIN

	DECLARE @offset int = @PageIndex * @PageSize

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
		  ,TotalCount = COUNT(1) OVER()
	  FROM [dbo].[Users]

	  ORDER BY Id

	  OFFSET @offset ROWS
	  FETCH NEXT @PageSize ROWS ONLY
END


GO
