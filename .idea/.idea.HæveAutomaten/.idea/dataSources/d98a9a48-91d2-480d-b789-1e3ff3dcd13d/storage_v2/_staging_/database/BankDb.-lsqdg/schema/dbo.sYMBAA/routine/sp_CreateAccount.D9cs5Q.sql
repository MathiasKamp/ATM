
        alter procedure [dbo].[sp_CreateAccount]

            @name              varchar(50)   = NULL,
            @lastName              varchar(50)   = NULL,
            @accountNumber             varchar(10)   = NULL,
            @cardNumber             varchar(16)   = NULL,
            @pinCode                varchar(4) = null,
            @balance                decimal(16,4)  = null

        AS
        BEGIN
            set nocount on

            insert into dbo.Account

            (
                name             ,
                lastName                  ,
                accountNumber                 ,
                cardNumber,
                pinCode,
                balance

            )
            VALUES
                (
                    @name            ,
                    @lastName                 ,
                    @accountNumber                ,
                    @cardNumber   ,
                    @pinCode,
                    @balance

                );

        end
        go