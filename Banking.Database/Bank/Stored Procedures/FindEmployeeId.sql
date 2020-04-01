CREATE   PROC [Bank].[FindEmployeeId]
(
	@email DataTypeMail
)
AS
BEGIN

	SELECT [Id] FROM [Bank].[Employee] 
	WHERE [Mail]=@email

END