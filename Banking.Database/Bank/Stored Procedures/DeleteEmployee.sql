CREATE   PROC [Bank].DeleteEmployee
(
	@EmployeeId int
)

AS
BEGIN
	
	DECLARE @result int

	DELETE [Bank].[Employee]  
	WHERE 
	Id=@EmployeeId

	IF @@ERROR=0
		SET @result=1
	ELSE
		SET @result=0 	

	SELECT @result 

END