alter procedure [dbo].[sp_WithDrawMoney]

    @name              varchar(50)   = NULL,
    @lastName              varchar(50)   = NULL,
    @amount                decimal(16,4)  = null

AS
BEGIN
    set nocount on

    update Account set balance = Account.balance - @amount  where name = @name and lastName = @lastName;
    
end
go

