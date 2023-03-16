CREATE PROCEDURE [dbo].[proc_Externaluser_CheckIfRegistrationExist] 
	@email			VARCHAR(MAX)
AS 
BEGIN 
	DECLARE 
	@EmailExists				BIT = 0
	
	-- Check if the name exists
	IF EXISTS (SELECT 
					r.Email
			   FROM ExternalUser r 
			   WHERE UPPER(LTRIM(RTRIM(r.email))) = UPPER(LTRIM(RTRIM(@email))))
    BEGIN 
        SET @EmailExists	 = 1 
    END 

    SELECT @EmailExists AS [FirstName]
END
GO