CREATE   PROC [Bank].[InsertEmployee]
(
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

	INSERT INTO [Bank].[Employee](FirstName,LastName,FullName,ContactNumber,Mail,DOB,ManagerId) 
	Values(@Firstname,@Lastname,@Fullname,@contactnumber,@mail,@dob,@ManagerId)

	SELECT CAST(SCOPE_IDENTITY() AS INT)

END