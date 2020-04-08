CREATE PROCEDURE [Account].[UpdateCustomerDetails]
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
	IF EXISTS (SELECT 'True' FROM [Account].[Account] WHERE @CustomerId = CustomerId )
	  BEGIN 
		UPDATE [Account].[Customer]
		SET FirstName=@FirstName, LastName=@LastName, 
		FullName=CONCAT(@FirstName,' ',@LastName),
		Address=@Address, ContactNumber=@ContactNumber, Mail=@Mail 
		WHERE Id=@CustomerId
		--PRINT 'Updated Successfully !!!'
		SELECT 'Updated Successfully !!!'
	  END
	ELSE
		SELECT 'Invalid Customer ID !!!!'
END