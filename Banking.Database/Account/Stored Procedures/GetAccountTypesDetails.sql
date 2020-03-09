CREATE PROCEDURE [Account].[GetAccountTypesDetails]
AS
BEGIN
	SELECT Id,Type,MinimumBalance,TransactionLimit FROM [Account].[AccountType]
END