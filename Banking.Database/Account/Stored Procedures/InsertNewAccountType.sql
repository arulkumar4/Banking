CREATE PROCEDURE [Account].[InsertNewAccountType]
(
	@AccountType VARCHAR (20),
	@MinimumBalance MONEY,
	@TransactionLimit MONEY
)
AS
BEGIN
	DECLARE @Type VARCHAR(20)
	DECLARE @Count INT
	SET @Type=(SELECT Type FROM [Account].[AccountType] WHERE Type=@AccountType)
	SET @Count=(SELECT Count(Type) FROM [Account].[AccountType])
	IF (@Type=@AccountType)
	  PRINT 'Account Type Already Exists !!!'
	ELSE
	  BEGIN
		BEGIN TRANSACTION
			DECLARE @icount INT
			INSERT INTO [Account].[AccountType]([Type],[MinimumBalance],[TransactionLimit])
			VALUES (@AccountType,@MinimumBalance,@TransactionLimit)		
			SET @icount=(SELECT COUNT(Type) FROM [Account].[AccountType])
			IF (@icount<=@Count)
			  BEGIN
				ROLLBACK
				SELECT 'Error Occured.Cannot Insert New AccountType !!!'
			  END
			ELSE
				SELECT 'New Account Type Added !!!'
				--PRINT 'New Account Type Added'
		COMMIT
	  END
END