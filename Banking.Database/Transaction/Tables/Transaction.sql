CREATE TABLE [Transaction].[Transaction] (
    [SLNO]              INT           IDENTITY (10000000, 1) NOT NULL,
    [Id]                AS            ('TR'+right(CONVERT([varchar],[SLNO]),(8))) PERSISTED NOT NULL,
    [IntialBalance]     MONEY         NULL,
    [TransferAmount]    MONEY         NULL,
    [AvailableBalance]  MONEY         NULL,
    [TransactionDate]   DATE          NULL,
    [SenderName]        VARCHAR (100) NULL,
    [ReceiverName]      VARCHAR (100) NULL,
    [status]            VARCHAR (10)  NOT NULL,
    [AccountId]         VARCHAR (20)  NOT NULL,
    [TransactionTypeId] VARCHAR (10)  NOT NULL,
    [ReciverAccountId]  VARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Account].[Account] ([Id]),
    CONSTRAINT [FK_RAccountId] FOREIGN KEY ([ReciverAccountId]) REFERENCES [Account].[Account] ([Id]),
    CONSTRAINT [FK_TransactionTypeId] FOREIGN KEY ([TransactionTypeId]) REFERENCES [Transaction].[TransactionType] ([Id])
);





