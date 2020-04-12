CREATE   PROC [Bank].[FindCustomerId]
(
	@email DataTypeMail
)
AS
BEGIN

	SELECT [Id] FROM [Account].[Customer] 
	WHERE [Mail]=@email

END