CREATE PROCEDURE [Account].[GetAllAccountByBalance]
(
@Amount MONEY
)
AS
BEGIN
	SELECT a.CustomerId, a.Number, c.FirstName,c.LastName,c.FullName, a.OpenDate, 
		   a.Status, a. Balance, at.Type AS AccountType ,c.ContactNumber, c.Mail
		   FROM [Account].[Customer] c
	JOIN [Account].[Account] a
	ON c.Id = a.CustomerId  
	JOIN [Account].[AccountType] at 
	ON a.AccountTypeId = at.Id   
	WHERE Balance<=@Amount AND Status=1
	
END