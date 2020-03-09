CREATE PROCEDURE[Account].[DeleteAccountType]
(
@AccId INT,
@AccountType VARCHAR (20)
)
AS
BEGIN
	DECLARE @AccType VARCHAR(20)
	SET @AccType=(SELECT Type FROM [Account].[AccountType] WHERE @AccountType=Type AND Id=@AccId)
	IF(@AccountType=@AccType)
		BEGIN 
		  DELETE FROM [Account].[AccountType]
		  WHERE Type=@AccountType AND Id=@AccId
		  SELECT 'Deleted Successfully !!'
		  --PRINT'Deleted Successfully !!!'
		END
	ELSE
		SELECT'Invalid AccountType / Id!!!'
END