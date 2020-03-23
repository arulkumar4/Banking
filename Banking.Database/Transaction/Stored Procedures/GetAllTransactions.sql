Create procedure [Transaction].GetAllTransactions (@AccountId varchar(20))
AS 
BEGIN
	set nocount on;
	Select  Id , [IntialBalance],[TransferAmount],[AvailableBalance],[TransactionDate],[SenderName],[ReceiverName],[status],[AccountId],[TransactionTypeId] ,[ReciverAccountId]
	From [Transaction].[Transaction] WITH (NOLOCK)
	where [AccountId]= @AccountId OR [ReciverAccountId] = @AccountId

END