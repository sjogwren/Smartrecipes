CREATE PROCEDURE  [dbo].[proc_Update_Recipe]  
(
	@RecipeID					INT,
	@Name						VARCHAR(MAX),
	@Instructions               VARCHAR(MAX),
	@IngredientsSelectedText	VARCHAR(MAX),
	@IngredientsDeletedText		VARCHAR(MAX),
	@DateAdded					DATETIME,
	@ImageName				    VARCHAR(255),
	@UserID						INT,
	@Username                   VARCHAR(255),
	@CreatedOn					DATETIME,
	@CreatedByUserID            INT
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
      [CreatedByUserID] = @CreatedByUserID  
   WHERE RecipeID = @RecipeID  

	DECLARE @TEMP_DELETED_INGREDIENTS TABLE
	(
		D_IngredientID INT,
		RecipeID INT
	)
	INSERT INTO @TEMP_DELETED_INGREDIENTS([D_IngredientID],[RecipeID])
	SELECT * FROM dbRecipe.dbo.SplitText_For_Insert(@IngredientsDeletedText,',',@RecipeID)

	DECLARE @TEMP_NEW_INGREDIENTS TABLE
	(
		N_IngredientID INT,
		RecipeID INT
	)
	INSERT INTO @TEMP_NEW_INGREDIENTS([N_IngredientID],[RecipeID])
	SELECT * FROM dbRecipe.dbo.SplitText_For_Insert(@IngredientsSelectedText,',',@RecipeID)



	DELETE RI
	FROM RecipeIngredients RI
	INNER JOIN @TEMP_DELETED_INGREDIENTS DI ON DI.D_IngredientID = RI.IngredientID
	WHERE RI.RecipeID = @RecipeID

	INSERT INTO RecipeIngredients(IngredientID, RecipeID)
	SELECT 
		NI.N_IngredientID,
		NI.RecipeID
	FROM @TEMP_NEW_INGREDIENTS NI
END