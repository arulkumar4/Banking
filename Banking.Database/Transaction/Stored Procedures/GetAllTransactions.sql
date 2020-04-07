Create procedure [Transaction].GetAllTransactions (@AccountId varchar(20))
AS 
BEGIN
	set nocount on;
	Select  TRN.Id , [IntialBalance],[TransferAmount],[AvailableBalance],[TransactionDate],[SenderName],[ReceiverName],[status],[AccountId],TRNTY.[Type] ,[ReciverAccountId]
	From [Transaction].[Transaction]  TRN WITH (NOLOCK) inner join [Transaction].[TransactionType]  TRNTY WITH (NOLOCK)
	ON TRN.TransactionTypeId = TRNTY.Id
	where [AccountId]= @AccountId OR [ReciverAccountId] = @AccountId

END