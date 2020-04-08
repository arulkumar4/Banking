--Procedure for Getting One Customer

CREATE PROCEDURE [Account].[GetOneCustomerDetails]
(
	@CustomerId VARCHAR(20),
	@AccNumber BIGINT
)
AS
BEGIN
	IF EXISTS (SELECT 'True' FROM [Account].[Account]	 
	WHERE @CustomerId = CustomerId)	  
		BEGIN
			SELECT  c.Id AS CustomerId,a.Number,c.FirstName,c.LastName, c.FullName,
					c.Mail,c.ContactNumber,a.Balance,at.Type AS AccountType 
			FROM [Account].[Customer] c
			RIGHT JOIN [Account].[Account] a
			ON c.Id = a.CustomerId AND @CustomerId=a.CustomerId 	
			JOIN [Account].[AccountType] at
			ON a.AccountTypeId = at.Id AND @AccNumber=a.Number
	    END
	ELSE
	  PRINT 'Invalid Credentials !!!'
END