CREATE FUNCTION [dbo].[SplitText]
(
  @List VARCHAR(max),
  @SplitOn NVARCHAR(5),
  @RecipeID INT
)

RETURNS @RtnValue table
(
  RecipeID INT,
  Value NVARCHAR(max)
)
AS

BEGIN
   IF (len(@List) <= 0)
   BEGIN
     RETURN 
   END

WHILE (Charindex(@SplitOn,@List) > 0)
   BEGIN

     INSERT INTO @RtnValue (RecipeID,value)
     SELECT 
     Value = ltrim(rtrim(Substring(@List,1,Charindex(@SplitOn,@List)-1))),
	 RecipeID = @RecipeID

     SET @List = Substring(@List,Charindex(@SplitOn,@List)+len(@SplitOn),len(@List))
   END

   INSERT INTO @RtnValue (RecipeID,value)
   SELECT   Value = ltrim(rtrim(@List)), RecipeID = @RecipeID

   RETURN
END