CREATE   PROC [Bank].[GetEmployees]
AS
BEGIN
	
	select e.Id,e.Mail,e.ContactNumber,e.DOB,e.Age,e.FirstName,e.LastName,e.FullName,e.ManagerId,u.PasswordHash as [Password]
	From [Bank].[Employee] e
	LEFT JOIN [dbo].[User] u ON e.Mail=u.Email 

END