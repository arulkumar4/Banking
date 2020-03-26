CREATE PROCEDURE [Account].[UpdateCustomerByEmployee]
(
	@CustomerId BIGINT,
	@FirstName DataTypeName,
	@LastName DataTypeName,
	@Address DataTypeAddress,      
	@ContactNumber DataTypeContactNumber,
	@Mail DataTypeMail
)
AS
BEGIN 
	IF EXISTS (SELECT 'True' FROM [Account].[Customer] WHERE @CustomerId = Id)
	  BEGIN 
		UPDATE [Account].[Customer]
		SET FirstName=@FirstName, LastName=@LastName, 
		FullName=CONCAT(@LastName,' ',@FirstName),
		Address= @Address, ContactNumber=@ContactNumber, Mail=@Mail 
		WHERE Id= @CustomerId
		SELECT FirstName,LastName,FullName,Address,ContactNumber,Mail
		FROM [Account].[Customer]
		WHERE @CustomerId = Id
	  END
	ELSE
		SELECT 'Invalid Customer ID !!!!'
END