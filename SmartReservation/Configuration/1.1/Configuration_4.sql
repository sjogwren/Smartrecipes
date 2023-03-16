CREATE TABLE Recipe
(
	[RecipeID] int primary key identity(1,1) not null,
	[Name] varchar(255) not null,
	[DateAdded] datetime not null,
	[Username] varchar(255) not null,
	[UserID] int not null,
	[ImageName] varchar(max) NULL,
	[Instructions] varchar(max) not null,
	[CreatedOn] [datetime] NULL,
	[CreatedByUserID] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[DeletedByUserID] [int] NULL
)