﻿CREATE TABLE [Transaction].[TransactionType] (
    [Id]   UNIQUEIDENTIFIER NOT NULL,
    [Type] VARCHAR (40)     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
