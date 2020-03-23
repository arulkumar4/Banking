CREATE   PROC [Bank].[UpdateEmployeeById]
(
	@id INT,
	@Firstname DataTypeName,
	@Lastname DataTypeName,
	@Fullname DataTypeName,
	@contactnumber DataTypeContactNumber, 
	@mail DataTypeMail,
	@dob Date,
	@ManagerId int

)
AS
BEGIN
	DECLARE @result int

	UPDATE [Bank].[Employee] 
	SET 
		FirstName=@Firstname,
		LastName=@Lastname,
	    FullName=@Fullname,
	    ContactNumber=@contactnumber, 
	    Mail=@mail,
	    DOB=@dob, 
	    ManagerId=@ManagerId
	WHERE
		Id=@id

	IF @@ERROR=0
		SET @result=1
	ELSE
		SET @result=0 	

	SELECT @result 

END