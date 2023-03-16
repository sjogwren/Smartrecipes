CREATE PROCEDURE  [dbo].[proc_Delete_Recipe]  
(
	@RecipeID					INT,
	@Name						VARCHAR(MAX),
	@Instructions               VARCHAR(MAX),
	@DateAdded					DATETIME,
	@ImageName				    VARCHAR(255),
	@UserID						INT,
	@Username                   VARCHAR(255),
	@CreatedOn					DATETIME,
	@CreatedByUserID            INT,
	@DeletedOn					DATETIME,
	@DeletedByUserID			INT
)
AS
BEGIN

   UPDATE [dbo].[Recipe]  
   SET [Name] = @Name  ,
      [DateAdded] = @DateAdded  ,
      [Username] = @Username,  
      [UserID] = @UserID  ,
      [ImageName] = @ImageName  ,
      [Instructions] = @Instructions ,
	  [CreatedOn] =  @CreatedOn,
      [CreatedByUserID] = @CreatedByUserID,
	  [DeletedOn] = @DeletedOn,
	  [DeletedByUserID] = @DeletedByUserID
   WHERE RecipeID = @RecipeID  

END