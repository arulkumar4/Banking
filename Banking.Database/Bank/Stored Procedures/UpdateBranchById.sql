CREATE   PROCEDURE [Bank].[UpdateBranchById]
(
	@Id INT,
	@name DataTypeName,
	@contactnumber DataTypeContactNumber,
	@cityid INT,
	@address DataTypeAddress
)
AS
BEGIN
	DECLARE @result int
	SET NOCOUNT ON;
	UPDATE [BANK].Branch 
	SET 
		[Name]=@name,
		ContactNumber=@contactnumber,
		CityId=@cityid,
		[Address]=@address
	WHERE Id=@Id

	IF @@ERROR=0
		SET @result=1
	ELSE
		SET @result=0 	

		SELECT @result 
END