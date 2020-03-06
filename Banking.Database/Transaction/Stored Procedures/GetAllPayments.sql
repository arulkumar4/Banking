Create procedure [Transaction].GetAllPayments (@AccountId varchar(20))
AS 
BEGIN
	set nocount on;
	Select  Id , [Type],[IntialBalance],[TransferAmount],[AvailableBalance],[SenderName],[ReciverName],[status],[AccountId],[Date]
	From [Transaction].[Payment] WITH (NOLOCK)
	where [AccountId]= @AccountId 

END