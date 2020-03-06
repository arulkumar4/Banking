CREATE TABLE [Transaction].[Transaction] (
    [Id]                VARCHAR (20)  NOT NULL,
    [IntialBalance]     MONEY         NULL,
    [TransferAmount]    MONEY         NULL,
    [AvailableBalance]  MONEY         NULL,
    [TransactionDate]   DATE          NULL,
    [SenderName]        VARCHAR (100) NULL,
    [ReceiverName]      VARCHAR (100) NULL,
    [status]            VARCHAR (10)  NULL,
    [AccountId]         VARCHAR (20)  NULL,
    [TransactionTypeId] VARCHAR (20)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Account].[Account] ([Id]),
    CONSTRAINT [FK_TransactionTypeId] FOREIGN KEY ([TransactionTypeId]) REFERENCES [Transaction].[TransactionType] ([Id])
);



