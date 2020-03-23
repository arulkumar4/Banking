CREATE TABLE [Account].[AccountType] (
    [Id]               INT          IDENTITY (1111, 1111) NOT NULL,
    [Type]             VARCHAR (20) DEFAULT ('Savings') NOT NULL,
    [MinimumBalance]   MONEY        DEFAULT ((1000)) NOT NULL,
    [TransactionLimit] MONEY        DEFAULT ((20000)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



