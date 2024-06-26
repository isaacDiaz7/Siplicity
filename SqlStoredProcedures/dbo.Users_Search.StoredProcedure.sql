/****** Object:  StoredProcedure [dbo].[Users_Search]    Script Date: 4/10/2024 10:44:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Isaac Diaz
-- Create date: 04/10/2024
-- Description: Search user based off of their first name.

-- MODIFIED BY: author
-- MODIFIED DATE:12/1/2020
-- Note:
-- =============================================

CREATE PROC [dbo].[Users_Search]
	@PageIndex int,
	@PageSize int,
	@Query nvarchar(250)

AS
/*
	DECLARE @PageIndex int = 0,
			@PageSize int = 4,
			@Query nvarchar(250) = 'Isaac'

	EXECUTE dbo.Users_Search @PageIndex,
							 @PageSize,
							 @Query

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

	  WHERE(FirstName LIKE '%' + @Query + '%')
	  ORDER BY Id

	  OFFSET @offset ROWS
	  FETCH NEXT @PageSize ROWS ONLY
END
GO
