CREATE PROCEDURE [Account].[UpdateCustomerDetails]
(
	@CustomerId VARCHAR(20),
	@Password VARCHAR(100),
	@FirstName DataTypeName,
	@LastName DataTypeName,
	@Address DataTypeAddress,      
	@ContactNumber DataTypeContactNumber,
	@Mail DataTypeMail
)
AS
BEGIN 
	IF EXISTS (SELECT 'True' FROM [Account].[Account] WHERE @CustomerId = CustomerId 
			   AND (SUBSTRING(master.dbo.fn_varbintohexstr(HashBytes('MD5', @Password)), 1, 100)= Password))
	  BEGIN 
		UPDATE [Account].[Customer]
		SET FirstName=@FirstName, LastName=@LastName, 
		FullName=CONCAT(@LastName,' ',@FirstName),
		Address= @Address, ContactNumber=@ContactNumber, Mail=@Mail 
		WHERE Id= @CustomerId
		--PRINT 'Updated Successfully !!!'
		SELECT 'Updated Successfully !!!'
	  END
	ELSE
		SELECT 'Invalid Customer ID / Password !!!!'
END