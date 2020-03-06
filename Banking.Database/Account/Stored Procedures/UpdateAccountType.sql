CREATE PROCEDURE[Account].[UpdateAccountType]
(
@AccId INT,
@AccountType VARCHAR (20),
@MinimumBalance MONEY,
@TransactionLimit MONEY
)
AS
BEGIN
	DECLARE @AccType VARCHAR(20)
	SET @AccType=(SELECT Type FROM [Account].[AccountType] WHERE @AccountType=Type AND Id=@AccId)
	IF(@AccountType=@AccType)
		BEGIN 
		  UPDATE [Account].[AccountType]
		  SET MinimumBalance=@MinimumBalance, TransactionLimit=@TransactionLimit
		  WHERE Type=@AccountType AND Id=@AccId
		  SELECT 'Updated Successfully !!!'
		  --PRINT'Updated Successfully !!!'
		END
	ELSE
		SELECT 'Invalid AccountType / Id!!!'
END