CREATE PROCEDURE [Account].[DeleteCustomerAccount]
(
	@Number BIGINT,
	@Password VARCHAR(100)
)
AS
BEGIN 
	DECLARE @AccId VARCHAR(100)
	DECLARE @Pass VARCHAR(100)
	DECLARE @Value BIT
	DECLARE @Status BIT
	SET @Pass=(SUBSTRING(master.dbo.fn_varbintohexstr(HashBytes('MD5', @Password)), 1, 100))
	SET @Value = (SELECT Status FROM [Account].[Account]
			      WHERE @Number=Number AND @Pass=Password)
	SET @AccId = (SELECT Id FROM [Account].[Account]
				  WHERE @Number=Number AND @Pass=Password)
	IF(@Value=1)
	 BEGIN
	  BEGIN TRANSACTION		
		UPDATE [Account].[Account]
		SET Number=0, Status=0, Password=0, Balance=0
		WHERE @Number=Number AND @Pass=Password
		SET @Status=(SELECT Status FROM [Account].[Account] WHERE @Number=Number AND @Pass=Password)
		IF(@Value=@Status)
			BEGIN
			  ROLLBACK
			  PRINT 'Error Occured !!!'
			END	
	    ELSE
			--PRINT 'Deleted Successfully !!!'			
	  COMMIT
	  SELECT 'Deleted Successfully !!!' 
	 END
	ELSE
	  SELECT 'Invalid AccountNumber/Password'
END