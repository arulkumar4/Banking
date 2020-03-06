CREATE PROCEDURE [Account].[GetOneCustomerDetails]
(
	@CustomerId VARCHAR(20),
	@AccNumber BIGINT,
	@Password VARCHAR(100)
)
AS
BEGIN
		IF EXISTS (SELECT 'True' FROM [Account].[Account]	 
		WHERE @CustomerId = CustomerId AND SUBSTRING(master.dbo.fn_varbintohexstr(HashBytes('MD5', @Password)), 1, 100)= Password)	  
		BEGIN
			SELECT  c.Id AS CustomerId,a.Number,c.FirstName,c.LastName, c.ContactNumber,
					a.Balance , at.Type AS AccountType FROM [Account].[Customer] c
			RIGHT JOIN [Account].[Account] a
			ON c.Id = a.CustomerId AND @CustomerId=a.CustomerId 	
			JOIN [Account].[AccountType] at
			ON a.AccountTypeId = at.Id AND @AccNumber=a.Number
	    END
	ELSE
	  PRINT 'Invalid Credentials !!!'
END