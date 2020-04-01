CREATE   PROC [Bank].[SearchEmployeeByKeyword]
(
	@keyword varchar(1000)
)
AS
BEGIN
	
	SELECT * From [Bank].[Employee] 
	WHERE
	Id				Like  '%'+@keyword+'%' OR
	FirstName		Like  '%'+@keyword+'%' OR
	LastName		Like  '%'+@keyword+'%' OR
	FullName		Like  '%'+@keyword+'%' OR
	Mail			Like  '%'+@keyword+'%' OR
	ContactNumber	Like  '%'+@keyword+'%' OR
	DOB             Like  '%'+@keyword+'%' OR
	Age             Like  '%'+@keyword+'%' 

END