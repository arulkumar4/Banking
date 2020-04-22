CREATE   PROC [Bank].[FindAccountNumber]
(
	@email DataTypeMail
)
AS
BEGIN

	--SELECT [Id] FROM [Account].[Customer] 
	--WHERE [Mail]=@email
	 SELECT Number FROM [Account].[Account]
	 WHERE CustomerId=
	 (SELECT [Id] FROM [Account].[Customer] 
	 WHERE [Mail]=@email)

END