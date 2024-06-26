/****** Object:  StoredProcedure [dbo].[Users_Update]    Script Date: 4/10/2024 10:44:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Isaac Diaz
-- Create date: 03/08/2024
-- Description: Updates user based off of their Id.

-- MODIFIED BY: author
-- MODIFIED DATE:12/1/2020
-- Note:
-- =============================================

CREATE PROC [dbo].[Users_Update]
	@Id int,
	@Email nvarchar(255),
	@FirstName nvarchar(50),
	@Mi nvarchar(2),
	@LastName nvarchar(50),
	@Password nvarchar(100),
	@StatusId int,
	@AvatarUrl nvarchar(255)

AS
/*
	DECLARE @Id int = 4,
			@Email nvarchar(255) = 'MikeLuth@gmail.com',
			@FirstName nvarchar(50) = 'Mike',
			@Mi nvarchar(2) = 'ML',
			@LastName nvarchar(50) = 'Luther',
			@Password nvarchar(50) = '1qaz1qaz!QAZ!QAZ',
			@StatusId int = 1,
			@AvatarUrl nvarchar(255) = 'Some random Avatar Url'

	EXECUTE dbo.Users_Update @Id,
							@Email,
							@FirstName,
							@Mi,
							@LastName,
							@Password,
							@StatusId,
							@AvatarUrl

*/

BEGIN

	DECLARE @DateModified datetime2(7) = GETUTCDATE()

	UPDATE [dbo].[Users]
	   SET [Email] = @Email
		  ,[FirstName] = @FirstName
		  ,[Mi] = @Mi
		  ,[LastName] = @LastName
		  ,[Password] = @Password
		  ,[StatusId] = @StatusId
		  ,[AvatarUrl] = @AvatarUrl
		  ,[DateModified] = @DateModified
	 WHERE Id = @Id

 END


GO
