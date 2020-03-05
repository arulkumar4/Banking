CREATE PROCEDURE [Bank].[AddBranch]
(
	@name DataTypeName,
	@contactnumber DataTypeContactNumber,
	@cityid int,
	@Address DataTypeAddress
)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [Bank].[Branch]([Name],ContactNumber,CityId,[Address]) 
	VALUES (@name, @contactnumber, @cityid, @Address)

	SELECT CAST(SCOPE_IDENTITY() AS INT)

END