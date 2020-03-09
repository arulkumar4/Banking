Create  Procedure [Transaction].UpdateTransactionType (@oldType varchar(40), @newType varchar(40))
AS 
Begin 
	set nocount on;
	DECLARE @result int;
	Update [Transaction].TransactionType 
	set Type=@newType 
	where Type=@oldType

	IF @@ERROR=0
		SET @result=1
	ELSE
		SET @result=0 	

	SELECT @result
End