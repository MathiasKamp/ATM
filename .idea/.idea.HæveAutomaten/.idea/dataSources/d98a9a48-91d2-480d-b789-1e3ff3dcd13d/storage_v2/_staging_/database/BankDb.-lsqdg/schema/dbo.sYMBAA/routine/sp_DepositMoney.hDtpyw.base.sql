create procedure [dbo].[sp_DepositMoney]

    @name              varchar(50)   = NULL,
    @lastName              varchar(50)   = NULL,
    @amount                decimal(16,4)  = null

AS
BEGIN
    set nocount on

    update Account set balance = @amount + Account.balance where name = @name and lastName = @lastName;

end
go

