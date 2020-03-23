CREATE   PROCEDURE [Bank].[DeleteBranch]
(
	@id INT
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @result int

	DELETE [BANK].Branch 
	WHERE
		Id=@id
	  
	IF @@ERROR=0
		SET @result=1
	ELSE
		SET @result=0 	

	SELECT @result 

END