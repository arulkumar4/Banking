CREATE TABLE [Account].[AccountType] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [Type]             VARCHAR (30)     NULL,
    [MinimumBalance]   MONEY            NULL,
    [TransactionLimit] MONEY            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

