Create Procedure [Transaction].AccountPayment (@TransferAmmount money , @SenderName varchar(100) ,@ReciverName varchar(100) , @AccountId Varchar(20),@Type Varchar(10))
AS
Begin

	set nocount on;
	Declare @intialBalance Money
	set @intialBalance=(select Balance From [Account].Account where Id=@AccountId)
	
		BEgin Transaction Debit
	

			Begin Try
			  If(@intialBalance > @TransferAmmount)
			   BEGIN
			
				Insert Into [Transaction].[Payment]
				Values(@Type,@intialBalance,@TransferAmmount,(@intialBalance-@TransferAmmount),@SenderName,@ReciverName,'SUCCESS',@AccountId,GETDATE());

				update [Account].[Account] Set Balance = (@intialBalance-@TransferAmmount) where Id=@AccountId;

				Select Id ,Type , [IntialBalance],[TransferAmount],[AvailableBalance],[SenderName],[ReciverName],[status],[AccountId],Date
				From [Transaction].[Payment] WITH (NOLOCK)
				where SLNO = SCOPE_IDENTITY();
				END
			  Else 
			   Begin 
			    RAISERROR ('Error raised in TRY block.',16,1);
			   End
		    End Try
		
			Begin catch
		    	Rollback Transaction Debit
				Insert Into [Transaction].[Payment]
					Values(@Type ,@intialBalance,0,0,@SenderName,@ReciverName,'FAILED',@AccountId,GETDATE());

			Select Id ,Type , [IntialBalance],[TransferAmount],[AvailableBalance],[SenderName],[ReciverName],[status],[AccountId]
					From [Transaction].[Payment] WITH (NOLOCK)
						where SLNO = SCOPE_IDENTITY();
				
		    End catch

			Commit Transaction Debit

	
End