create procedure [dbo].[sp_ChangeMoneyAmount]

    @name              varchar(50)   = NULL,
    @lastName              varchar(50)   = NULL,
    @balance                decimal(16,4)  = null

AS
BEGIN
    set nocount on

    update Account set balance = @balance where name = @name and lastName = @lastName;
    
end
go

