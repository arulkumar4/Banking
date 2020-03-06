Create Procedure [Transaction].GetTransactionTypes
AS
Begin
	set nocount on;
	Select Id,Type 
	From [Transaction].TransactionType
End