CREATE   PROC [Bank].DeleteCityDetail
(
	@Id INT
)

AS
BEGIN

	DECLARE @result int

	DELETE Bank.City 
	Where [Id]=@Id

	IF @@ERROR=0
		SET @result=1
	ELSE
		SET @result=0 	

	SELECT @result
	
END