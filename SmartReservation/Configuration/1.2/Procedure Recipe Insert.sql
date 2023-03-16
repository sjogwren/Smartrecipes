CREATE PROCEDURE  [dbo].[proc_Recipe_Insert]
(
    @Name						VARCHAR(MAX),
	@Instructions               VARCHAR(MAX),
	@IngredientsSelectedText	VARCHAR(MAX),
	@DateAdded					DATETIME,
	@ImageName				    VARCHAR(255),
	@UserID						INT ,
	@Username                   VARCHAR(255),
	@CreatedOn					DATETIME,
	@CreatedByuserID            INT 
)
AS
BEGIN
DECLARE		@RecipeID	INT
DECLARE     @IsInsertCompletedSuccessfully BIT = 0

	INSERT INTO [dbo].[Recipe]
           ([Name],[Instructions],[ImageName],[DateAdded],[UserID],[Username]
            ,[CreatedOn],[CreatedByUserID])
     VALUES
           (
		     @Name,@Instructions,@ImageName,@DateAdded,@UserID,@Username,@CreatedOn,@CreatedByuserID)

    SET    @RecipeID = SCOPE_IDENTITY()

	INSERT INTO [dbo].[RecipeIngredients]([IngredientID],[RecipeID])

    SELECT * FROM dbRecipe.dbo.SplitText_For_Insert(@IngredientsSelectedText,',',@RecipeID)
 END