CREATE   PROC [Bank].DeleteManager
(
	@ManagerId int

)

AS
BEGIN
	
	DECLARE @result int

	DELETE [Bank].[Manager]  
	WHERE 
	Id=@ManagerId

	IF @@ERROR=0
		SET @result=1
	ELSE
		SET @result=0 	

	SELECT @result 

END