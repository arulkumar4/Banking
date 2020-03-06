CREATE TABLE [Transaction].[Payment] (
    [SLNO]             INT           IDENTITY (10000000, 1) NOT NULL,
    [Id]               AS            ('PY'+right(CONVERT([varchar],[SLNO]),(8))) PERSISTED NOT NULL,
    [Type]             VARCHAR (10)  NOT NULL,
    [IntialBalance]    MONEY         NOT NULL,
    [TransferAmount]   MONEY         NOT NULL,
    [AvailableBalance] MONEY         NOT NULL,
    [SenderName]       VARCHAR (100) NOT NULL,
    [ReciverName]      VARCHAR (100) NOT NULL,
    [status]           VARCHAR (10)  NOT NULL,
    [AccountId]        VARCHAR (20)  NOT NULL,
    [Date]             DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PaymentAccountId] FOREIGN KEY ([AccountId]) REFERENCES [Account].[Account] ([Id])
);





