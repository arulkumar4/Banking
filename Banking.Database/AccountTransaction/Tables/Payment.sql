CREATE TABLE [AccountTransaction].[Payment] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [Type]             VARCHAR (40)     NULL,
    [IntialBalance]    MONEY            NULL,
    [TransferAmount]   MONEY            NULL,
    [AvailableBalance] MONEY            NULL,
    [SenderName]       VARCHAR (100)    NULL,
    [ReciverName]      VARCHAR (100)    NULL,
    [status]           VARCHAR (10)     NULL,
    [AccountId]        UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PaymentAccountId] FOREIGN KEY ([AccountId]) REFERENCES [CustomerAccount].[Account] ([Id])
);

