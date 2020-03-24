CREATE PROCEDURE [Account].[InsertCustomer]
(
	@FirstName DataTypeName,
	@LastName DataTypeName,
	@Address DataTypeAddress,      
	@ContactNumber DataTypeContactNumber,
	@Gender  VARCHAR (6),
	@DOB DATE,
	@Mail DataTypeMail,
	@Balance MONEY,
	@Password VARCHAR(100),
	@AccType VARCHAR(20),
	@EmpId INT
)
AS
BEGIN
	SET NOCOUNT ON
	IF EXISTS(SELECT 'True' FROM [Bank].[Employee] WHERE @EmpId=Id)
	BEGIN
		IF EXISTS(SELECT 'True' FROM [Account].[Customer] WHERE @ContactNumber=ContactNumber OR @Mail=Mail )
			PRINT 'Phone/Email already exists!' 
		ELSE
		BEGIN
		 BEGIN TRANSACTION	
		    DECLARE @Id BIGINT
			INSERT INTO [Account].[Customer]([FirstName],[LastName],[FullName],[Address],[ContactNumber],[Gender],[DOB],[Mail],[EmployeeId])
			VALUES (@FirstName,@LastName,CONCAT(@LastName,' ',@FirstName),@Address,@ContactNumber,@Gender,@DOB,@Mail,@EmpId)
			SET @Id=(SELECT MAX(Id) FROM [Account].[Customer])
			 BEGIN 
				DECLARE @AccNO BIGINT 
				DECLARE @Pass VARCHAR(100)
				SET @Pass=(SUBSTRING(master.dbo.fn_varbintohexstr(HashBytes('MD5', @Password)), 1, 100))
				SET @AccNo = LEFT(CAST(RAND()*999999999999 AS BIGINT),12)
				IF(@AccNo NOT IN(SELECT Number FROM [Account].[Account]))
				 BEGIN 
					DECLARE @type VARCHAR(20) 
					SET @type = (SELECT Type FROM Account.AccountType WHERE Type = @AccType)
					IF(@type = @AccType)
					  BEGIN
						DECLARE @COUNT INT
						DECLARE @TypeId INT
						DECLARE @CustomerId BIGINT
						SET @CustomerId = (SELECT CustomerId FROM [Account].[Account] WHERE CustomerId = @CustomerId)
						SET @COUNT = (SELECT COUNT(Id) FROM [Account].[Account])
						SET @TypeId = (SELECT Id FROM [Account].[AccountType] WHERE Type = @AccType)
						IF (@COUNT = 0 AND @Balance>1000)
							BEGIN 
								INSERT INTO [Account].[Account]([Id],[Number],[Password],[Balance],[OpenDate],[Status],[CustomerId],[AccountTypeId])
								VALUES('DBG-' + RIGHT(REPLACE(NEWID(),'-',''),16),@AccNo,@Pass,@Balance,GETDATE(),'1',@Id,@TypeId)
							END
						ELSE IF(@Id NOT IN (SELECT CustomerId FROM [Account].[Account] WHERE CustomerId=@Id))				
						BEGIN
							IF @Balance>1000
								INSERT INTO [Account].[Account]([Id],[Number],[Password],[Balance],[OpenDate],[Status],[CustomerId],[AccountTypeId])
								VALUES('DBG-' + RIGHT(REPLACE(NEWID(),'-',''),16),@AccNo,@Pass,@Balance,GETDATE(),'1',@Id,@TypeId)
							ELSE
								PRINT 'Balance must be greater than 1000'
						END 
						SET @CustomerId = (SELECT CustomerId FROM [Account].[Account] WHERE CustomerId = @CustomerId)
						IF(@CustomerId!=@Id)		   
						  BEGIN
							ROLLBACK 
							SELECT 'Process Failed. Check Your Data And Please Try Again !!!'
						  END	
						ELSE
							SELECT a.CustomerId, a.Number, c.FirstName,c.LastName,c.FullName,c.ContactNumber,
								   c.Mail,a. Balance, at.Type AS AccountType
							FROM [Account].[Customer] c
							JOIN [Account].[Account] a
							ON c.Id = a.CustomerId
							JOIN [Account].[AccountType] as at
							ON at.Id=a.AccountTypeId
							WHERE a.CustomerId=@Id
							--PRINT 'Added Successfully !!!'
					 END
				 END
			 END
		 COMMIT
		END
	END
END