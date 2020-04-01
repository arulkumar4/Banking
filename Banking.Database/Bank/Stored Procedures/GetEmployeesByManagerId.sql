CREATE   PROC [Bank].[GetEmployeesByManagerId]
(
	@managerId INT
)
AS
BEGIN

	SELECT * FROM [Bank].[Employee] 
	WHERE ManagerId=@managerId

END