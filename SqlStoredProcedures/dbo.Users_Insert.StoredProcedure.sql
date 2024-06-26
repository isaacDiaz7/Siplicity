/****** Object:  StoredProcedure [dbo].[Users_Insert]    Script Date: 4/10/2024 10:44:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Isaac Diaz
-- Create date: 03/08/2024
-- Description: Add a new user to the User table.

-- MODIFIED BY: author
-- MODIFIED DATE:12/1/2020
-- Note:
-- =============================================

CREATE PROC [dbo].[Users_Insert]
	@Email nvarchar(255),
	@FirstName nvarchar(50),
	@Mi nvarchar(2),
	@Lastname nvarchar(50),
	@Password nvarchar(100),
	@StatusId int,
	@AvatarUrl nvarchar(255),
	@Id int OUTPUT

AS
/*
	DECLARE @Email nvarchar(255) = 'Potato@gmail.com',
			@FirstName nvarchar(50) = 'Potato',
			@Mi nvarchar(2) = 'PT',
			@LastName nvarchar(50) = 'Tomato',
			@Password nvarchar(100) = '1qaz1qaz!QAZ!QAZ',
			@StatusId int = 1,
			@AvatarUrl nvarchar(255) = 'Some random Avatar Url',
			@Id int = 0

	EXECUTE dbo.Users_Insert @Email,
							@FirstName,
							@Mi,
							@LastName,
							@Password,
							@StatusId,
							@AvatarUrl,
							@Id OUTPUT
*/

BEGIN

	INSERT INTO [dbo].[Users]
			   ([Email]
			   ,[FirstName]
			   ,[Mi]
			   ,[LastName]
			   ,[Password]
			   ,[StatusId]
			   ,AvatarUrl)
		 VALUES
			   (@Email
			   ,@FirstName
			   ,@Mi
			   ,@LastName
			   ,@Password
			   ,@StatusId
			   ,@AvatarUrl)

	SET @Id = SCOPE_IDENTITY()


END

GO
