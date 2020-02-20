CREATE TABLE [AccountTransaction].[Transaction] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [IntialBalance]     MONEY            NULL,
    [TransferAmount]    MONEY            NULL,
    [AvailableBalance]  MONEY            NULL,
    [TransactionDate]   DATE             NULL,
    [SenderName]        VARCHAR (100)    NULL,
    [ReceiverName]      VARCHAR (100)    NULL,
    [status]            VARCHAR (10)     NULL,
    [AccountId]         UNIQUEIDENTIFIER NULL,
    [TransactionTypeId] UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [CustomerAccount].[Account] ([Id]),
    CONSTRAINT [FK_TransactionTypeId] FOREIGN KEY ([TransactionTypeId]) REFERENCES [AccountTransaction].[TransactionType] ([Id])
);

