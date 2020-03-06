CREATE TABLE [Account].[Account] (
    [Id]            VARCHAR (20)  NOT NULL,
    [Number]        BIGINT        NOT NULL,
    [Password]      VARCHAR (100) NOT NULL,
    [Balance]       MONEY         NULL,
    [OpenDate]      DATE          NULL,
    [Status]        BIT           NULL,
    [CustomerId]    BIGINT        NOT NULL,
    [AccountTypeId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([OpenDate]<getdate()),
    CONSTRAINT [FK_AccountTypeId] FOREIGN KEY ([AccountTypeId]) REFERENCES [Account].[AccountType] ([Id]),
    CONSTRAINT [FK_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Account].[Customer] ([Id])
);



