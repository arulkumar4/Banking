Create Procedure [Transaction].InsertTransactionType (@TType varchar(40))
AS
Begin
	set nocount on;
	DECLARE @result int;
	Insert Into [Transaction].TransactionType (Type) 
	values(@TType)
	IF @@ERROR=0
		SET @result=1
	ELSE
		SET @result=0 	

	SELECT @result 
END