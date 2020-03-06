
Create Procedure [Transaction].DebitTransaction (@TransferAmmount money , @SenderName varchar(100) ,@ReciverName varchar(100) , @AccountId Varchar(20),@TransactionTypeId Varchar(10),@ReciverAccountId Varchar(20))
AS
Begin

	set nocount on;
	Declare @intialBalance Money
	set @intialBalance=(select Balance From [Account].Account where Id=@AccountId)
	
		BEgin Transaction Debit
	

			Begin Try
			  If(@intialBalance > @TransferAmmount)
			   BEGIN
				Insert Into [Transaction].[Transaction]
				Values(@intialBalance,@TransferAmmount,(@intialBalance-@TransferAmmount),GetDate(),@SenderName,@ReciverName,'SUCCESS',@AccountId,@TransactionTypeId,@ReciverAccountId);

				update [Account].[Account] 
				Set Balance = (@intialBalance-@TransferAmmount) 
				where Id=@AccountId;

				update [Account].[Account] 
				Set Balance +=@TransferAmmount 
				where Id=@ReciverAccountId;

				Select Id , [IntialBalance],[TransferAmount],[AvailableBalance],[TransactionDate],[SenderName],[ReceiverName],[status],[AccountId],[TransactionTypeId] ,[ReciverAccountId]
				From [Transaction].[Transaction] WITH (NOLOCK)
			   where SLNO = SCOPE_IDENTITY();
				END
			  Else 
			   Begin 
			    RAISERROR ('Error raised in TRY block.',16,1);
			   End
		    End Try
		
			Begin catch
		    	Rollback Transaction Debit
				Insert Into [Transaction].[Transaction]
				Values(@intialBalance,0,0,GetDate(),@SenderName,@ReciverName,'FAILED',@AccountId,@TransactionTypeId,@ReciverAccountId);

				Select Id , [IntialBalance],[TransferAmount],[AvailableBalance],[TransactionDate],[SenderName],[ReceiverName],[status],[AccountId],[TransactionTypeId] ,[ReciverAccountId]
				From [Transaction].[Transaction] WITH (NOLOCK)
				where SLNO = SCOPE_IDENTITY();
				
		    End catch

			Commit Transaction Debit

	
End