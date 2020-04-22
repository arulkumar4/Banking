CREATE PROCEDURE [Account].[GetOneAccountType]
(
@AccId INT
)
AS
BEGIN
	DECLARE @Id INT
	SET @Id=(SELECT Id FROM [Account].[AccountType] WHERE Id=@AccId)
	IF(@AccId=@Id)
		BEGIN 
		  SELECT * FROM [Account].[AccountType]
		  WHERE Id=@AccId
		END
	ELSE
		PRINT'Invalid Account Type Id!!!'
END