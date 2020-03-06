CREATE PROCEDURE [Account].[GetAllAccountByAccountType]
(
	@AccountType VARCHAR(20)
)
AS
BEGIN
	SELECT a.CustomerId, a.Number, c.FirstName,c.LastName,c.FullName, a.OpenDate, 
		   a.Status, a. Balance, at.Type AS AccountType ,c.ContactNumber, c.Mail
		   FROM [Account].[Customer] c
	JOIN [Account].[Account] a
	ON c.Id = a.CustomerId
	JOIN [Account].[AccountType] at 
	ON a.AccountTypeId = at.Id AND @AccountType=at.Type 
	WHERE a.Status=1
END