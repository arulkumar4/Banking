CREATE TABLE [Transaction].[TransactionType] (
    [SLNO] INT          IDENTITY (1, 1) NOT NULL,
    [Id]   AS           ('TY'+right(CONVERT([varchar],[SLNO]),(8))) PERSISTED NOT NULL,
    [Type] VARCHAR (40) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);





