CREATE   PROC [Bank].[UpdateMangersById]
(
	@id INT,
	@Firstname DataTypeName,
	@Lastname DataTypeName,
	@Fullname DataTypeName,
	@contactnumber DataTypeContactNumber, 
	@mail DataTypeMail,
	@dob Date,
	@Experience int,
	@BranchId int

)
AS
BEGIN
	DECLARE @result int

	UPDATE [Bank].[Manager] 
	SET 
		FirstName=@Firstname,
		LastName=@Lastname,
	    FullName=@Fullname,
	    ContactNumber=@contactnumber, 
	    Mail=@mail,
	    DOB=@dob, 
	    Experience=@Experience,
	    BranchId=@BranchId
	WHERE
		Id=@id

	IF @@ERROR=0
		SET @result=1
	ELSE
		SET @result=0 	

	SELECT @result 

END