CREATE PROCEDURE [Account].[GetCustomerDetails]
(
	@CustomerId VARCHAR(20),
	@AccNumber BIGINT
)
AS
BEGIN
	IF EXISTS (SELECT * FROM [Account].[Account] WHERE @CustomerId=CustomerId AND @AccNumber=Number)
	  BEGIN
		SELECT a.CustomerId, a.Number, c.FirstName,c.LastName,c.FullName,c.ContactNumber,
			   c.Mail,a. Balance, at.Type AS AccountType, a.OpenDate, a. Status
		FROM [Account].[Customer] c
		JOIN [Account].[Account] a
		ON c.Id = a.CustomerId AND @CustomerId=a.CustomerId
		JOIN [Account].[AccountType] at
		ON a.AccountTypeId = at.Id AND @AccNumber=a.Number
	  END
	ELSE
	  PRINT 'Invalid Credentials !!!'
END