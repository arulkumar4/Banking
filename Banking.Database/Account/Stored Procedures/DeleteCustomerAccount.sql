CREATE PROCEDURE [Account].[DeleteCustomerAccount]
(
@Number BIGINT
)
AS
BEGIN 
DECLARE @AccId VARCHAR(100)
DECLARE @Value BIT
DECLARE @Status BIT
SET @Value = (SELECT Status FROM [Account].[Account]
     WHERE @Number=Number)
IF(@Value=1)
BEGIN
 BEGIN TRANSACTION	
UPDATE [Account].[Account]
SET Number=0, Status=0, Password=0, Balance=0
WHERE @Number=Number 
SET @Status=(SELECT Status FROM [Account].[Account] WHERE @Number=Number)
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