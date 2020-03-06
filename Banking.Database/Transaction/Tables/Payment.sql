CREATE TABLE [Transaction].[Payment] (
    [Id]               VARCHAR (20)  NOT NULL,
    [Type]             VARCHAR (40)  NULL,
    [IntialBalance]    MONEY         NULL,
    [TransferAmount]   MONEY         NULL,
    [AvailableBalance] MONEY         NULL,
    [SenderName]       VARCHAR (100) NULL,
    [ReciverName]      VARCHAR (100) NULL,
    [status]           VARCHAR (10)  NULL,
    [AccountId]        VARCHAR (20)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Payment_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Account].[Account] ([Id]),
    CONSTRAINT [FK_PaymentAccountId] FOREIGN KEY ([AccountId]) REFERENCES [Account].[Account] ([Id])
);



