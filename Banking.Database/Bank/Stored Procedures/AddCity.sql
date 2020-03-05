CREATE   PROC [Bank].[AddCity]
(
	@name DataTypeName
)

AS
BEGIN

	INSERT INTO [Bank].[City]([Name]) VALUES(@name)

	SELECT CAST(SCOPE_IDENTITY() AS INT)

END