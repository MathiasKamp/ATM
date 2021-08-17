CREATE procedure dbo.sp_CreateAccount

    @name              varchar(50)   = NULL,
    @lastName              varchar(50)   = NULL,
    @accountNumber             varchar(10)   = NULL,
    @cardNumber             varchar(16)   = NULL,
    @pinCode                tinyint = null
    
AS
BEGIN
    set nocount on

    insert into dbo.Account

    (
        name             ,
        lastName                  ,
        accountNumber                 ,
        cardNumber,
        pinCode
    
    )
    VALUES
        (
            @name            ,
            @lastName                 ,
            @accountNumber                ,
            @cardNumber   ,
            @pinCode
         
        ); 
    
    end
go

