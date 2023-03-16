CREATE PROCEDURE [dbo].[proc_CheckIfRecipeExist] 
	@Name			VARCHAR(MAX)
AS 

BEGIN 
	DECLARE 
	@RecipeExists				BIT = 0
	
	-- Check if the name exists
	IF EXISTS (SELECT 
					r.Name
			   FROM Recipe r 
			   WHERE UPPER(LTRIM(RTRIM(r.Name))) = UPPER(LTRIM(RTRIM(@Name)))
			   AND r.DeletedOn IS NULL)
    BEGIN 
        SET @RecipeExists	 = 1 
    END 

    SELECT @RecipeExists AS [RecipeID]
END

GO