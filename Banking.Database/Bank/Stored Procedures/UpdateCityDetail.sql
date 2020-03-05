CREATE   PROC [Bank].UpdateCityDetail
(
	@Id INT,
	@Name DataTypeName
)

AS
BEGIN
	DECLARE @result int

	UPDATE Bank.City 
	SET [Name]=@Name 
	Where [Id]=@Id

	IF @@ERROR=0
		SET @result=1
	ELSE
		SET @result=0 	

	SELECT @result 

END