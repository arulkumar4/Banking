CREATE PROCEDURE [Account].[UpdateAccountPassword]
(
	@Number VARCHAR(100),
	@OldPassword VARCHAR(100),
	@NewPassword VARCHAR(100)
)
AS
BEGIN
	IF EXISTS (SELECT 'True' FROM [Account].[Account] WHERE Number=@Number
			   AND (SUBSTRING(master.dbo.fn_varbintohexstr(HashBytes('MD5', @OldPassword)), 1, 100)= Password))
	  BEGIN
	     BEGIN TRANSACTION
			UPDATE [Account].[Account]
			SET Password=(SUBSTRING(master.dbo.fn_varbintohexstr(HashBytes('MD5', @NewPassword)), 1, 100))
			WHERE Number=@Number
			DECLARE @password VARCHAR(100)
		    SET @password=(SELECT Password FROM [Account].[Account] WHERE Number=@Number)
			IF(@password!=(SUBSTRING(master.dbo.fn_varbintohexstr(HashBytes('MD5', @NewPassword)), 1, 100)))
				BEGIN
				  ROLLBACK
				  PRINT 'Transaction Failed !!!'
				END
			ELSE
				SELECT 'Password Updated Successfully!!!'
				--PRINT 'Password Updated Successfully!!!'
		 COMMIT
	  END
	ELSE
	  SELECT 'Invalid Account Number / Password'
END