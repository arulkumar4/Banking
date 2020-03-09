CREATE PROCEDURE [Account].[GetOneAccountType]
(
@AccId INT,
@AccountType VARCHAR(20)
)
AS
BEGIN
	DECLARE @AccType VARCHAR(20)
	SET @AccType=(SELECT Type FROM [Account].[AccountType] WHERE @AccountType=Type AND Id=@AccId)
	IF(@AccountType=@AccType)
		BEGIN 
		  SELECT * FROM [Account].[AccountType]
		  WHERE Type=@AccountType AND Id=@AccId
		END
	ELSE
		PRINT'Invalid AccountType / Id!!!'
END