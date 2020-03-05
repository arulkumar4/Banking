CREATE   PROC [Bank].[GetMangersById]
(
	@id INT
)
AS
BEGIN

	SELECT * FROM [Bank].[Manager] 
	WHERE Id=@id

END