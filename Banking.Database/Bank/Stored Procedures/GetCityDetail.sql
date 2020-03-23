CREATE   PROC [Bank].GetCityDetail
(
	@ID INT
)

AS
BEGIN

	SELECT * FROM Bank.City where Id=@ID

END