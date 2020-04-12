CREATE   PROC [Bank].[FindManagerId]
(
	@email DataTypeMail
)
AS
BEGIN

	SELECT [Id] FROM [Bank].[Manager] 
	WHERE [Mail]=@email

END