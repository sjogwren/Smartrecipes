CREATE TABLE [dbo].[ExternalUserRole](
	[UserRoleID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[ExternalUserID] [int] NULL,
	[RoleID] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedByUserID] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[DeletedByUserID] [int] NULL
)