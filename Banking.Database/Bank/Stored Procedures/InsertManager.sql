CREATE   PROC [Bank].[InsertManager]
(
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

	INSERT INTO [Bank].[Manager](FirstName,LastName,FullName,ContactNumber,Mail,DOB,Experience,BranchId) 
	Values(@Firstname,@Lastname,@Fullname,@contactnumber,@mail,@dob,@Experience,@BranchId)

	SELECT CAST(SCOPE_IDENTITY() AS INT)

END