﻿CREATE PROCEDURE [Account].[GetAllCustomers]
AS
BEGIN
	SELECT a.CustomerId, a.Number,c.FirstName,c.LastName, a.OpenDate,a. Balance,c.Gender,c.[Address],a.[Password],
		   a.Status, at.Type AS AccountType ,c.ContactNumber, c.Mail,c.FullName,c.DOB
	FROM [Account].[Customer] c
	RIGHT JOIN [Account].[Account] a
	ON c.Id = a.CustomerId
	JOIN [Account].[AccountType] at
	ON a.AccountTypeId = at.Id 
	WHERE a.Status=1
END