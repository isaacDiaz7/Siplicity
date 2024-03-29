/****** Object:  StoredProcedure [dbo].[User_Insert]    Script Date: 3/7/2024 11:35:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE proc [dbo].[User_Insert]
	@FirstName nvarchar(50),
	@Lastname nvarchar(50),
	@Id int OUTPUT

as
/*
	Declare @FirstName nvarchar(50) = 'Isaac',
			@LastName nvarchar(50) = 'Diaz',
			@Id int = 0

	Execute dbo.User_Insert @FirstName,
							@LastName,
							@Id OUTPUT
*/

Begin

	INSERT INTO [dbo].[User]
			   ([FirstName]
			   ,[LastName])
		 VALUES
			   (@FirstName
			   ,@LastName)

	SET @Id = SCOPE_IDENTITY()


End

GO
