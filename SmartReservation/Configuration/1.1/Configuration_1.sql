CREATE TABLE [dbo].[ExternalUser](
	[ExternalUserID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](255) NULL,
	[FirstName] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
	[PasswordHash] [varchar](255) NULL,
	[SecurityStamp] [varchar](255) NULL,
	[PhoneNumber] [varchar](255) NULL,
	[PhoneNumberConfirmed] [bit] NULL,
	[Email] [varchar](255) NULL,
	[EmailConfirmed] [bit] NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NULL,
	[AccessFailedCount] [int] NULL
	)

