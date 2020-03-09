Create procedure [Transaction].AccountTransaction(@AccountId Varchar(20))
as
BEgin
	set nocount on;
	with WholeTransactions (Id ,[TransactionTypeId] , [IntialBalance],[TransferAmount],[AvailableBalance],[SenderName],[ReceiverName],[status],[AccountId],[ReciverAccountId],[TransactionDate])
	as
	(Select  Id , [Type],[IntialBalance],[TransferAmount],[AvailableBalance],[SenderName],[ReciverName],[status],[AccountId],'NULL' as [ReciverAccountId],[Date]
	From [Transaction].[Payment] WITH (NOLOCK) 
	where [AccountId]= @AccountId

	Union all
	Select  Id ,[TransactionTypeId] , [IntialBalance],[TransferAmount],[AvailableBalance],[SenderName],[ReceiverName],[status],[AccountId],[ReciverAccountId],[TransactionDate]
	From [Transaction].[Transaction] WITH (NOLOCK)
	where [AccountId]= @AccountId OR [ReciverAccountId] = @AccountId

	)
	Select * From WholeTransactions order by [TransactionDate] DESC
END