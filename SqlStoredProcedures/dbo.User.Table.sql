/****** Object:  Table [dbo].[User]    Script Date: 3/7/2024 11:35:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](255) NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[Mi] [nvarchar](2) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NULL,
	[StatusId] [int] NULL,
	[AvatarUrl] [nvarchar](255) NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_DateCreated]  DEFAULT (getutcdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_DateModified]  DEFAULT (getutcdate()) FOR [DateModified]
GO
