--Exec [Bank].[GetEmployeeById] '123'
CREATE   PROC [Bank].[GetEmployeeById]
(
	@id INT
)
AS
BEGIN

	SELECT * FROM [Bank].[Employee] 
	WHERE Id=@id

END