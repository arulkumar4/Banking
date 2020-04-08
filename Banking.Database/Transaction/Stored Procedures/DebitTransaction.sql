CREATE Procedure [Transaction].DebitTransaction (@TransferAmmount money , @SenderName varchar(100) ,@ReciverName varchar(100) , @AccountId Varchar(20),@TransactionTypeId Varchar(10),@ReciverAccountId Varchar(20))
AS
Begin

	set nocount on;
	Declare @intialBalance Money
	set @intialBalance=(select Balance From [Account].Account where Id=@AccountId)
	
		BEgin Transaction Debit
	

			Begin Try
			  If(@intialBalance >= @TransferAmmount)
			   BEGIN
				Insert Into [Transaction].[Transaction]
				Values(@intialBalance,@TransferAmmount,(@intialBalance-@TransferAmmount),GetDate(),@SenderName,@ReciverName,'SUCCESS',@AccountId,@TransactionTypeId,@ReciverAccountId);

				update [Account].[Account] 
				Set Balance = (@intialBalance-@TransferAmmount) 
				where Id=@AccountId;

				update [Account].[Account] 
				Set Balance +=@TransferAmmount 
				where Id=@ReciverAccountId;

				Select TRN.Id , [IntialBalance],[TransferAmount],[AvailableBalance],[TransactionDate],[SenderName],[ReceiverName],[status],[AccountId],TRNTY.[Type] ,[ReciverAccountId]
				From [Transaction].[Transaction] TRN WITH (NOLOCK) inner join [Transaction].[TransactionType]  TRNTY WITH (NOLOCK)
				ON TRN.TransactionTypeId = TRNTY.Id
			   where TRN.SLNO = SCOPE_IDENTITY();
				END
			  Else 
			   Begin 
			    RAISERROR ('Error raised in TRY block.',16,1);
			   End
			   Commit Transaction Debit
		    End Try
		
			Begin catch
		    	Rollback Transaction Debit
				Insert Into [Transaction].[Transaction]
				Values(@intialBalance,0,0,GetDate(),@SenderName,@ReciverName,'FAILED',@AccountId,@TransactionTypeId,@ReciverAccountId);

				Select TRN.Id , [IntialBalance],[TransferAmount],[AvailableBalance],[TransactionDate],[SenderName],[ReceiverName],[status],[AccountId],TRNTY.[Type] ,[ReciverAccountId]
				From [Transaction].[Transaction] TRN WITH (NOLOCK) inner join [Transaction].[TransactionType]  TRNTY WITH (NOLOCK)
				ON TRN.TransactionTypeId = TRNTY.Id
			   where TRN.SLNO = SCOPE_IDENTITY();
		    End catch

End