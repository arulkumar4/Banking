CREATE TABLE [CustomerAccount].[Account] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [Number]        VARCHAR (20)     NULL,
    [Balance]       MONEY            NULL,
    [OpenDate]      DATE             NULL,
    [Status]        BIT              NULL,
    [CustomerId]    UNIQUEIDENTIFIER NULL,
    [AccountTypeId] UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([OpenDate]<getdate()),
    CONSTRAINT [FK_AccountTypeId] FOREIGN KEY ([AccountTypeId]) REFERENCES [CustomerAccount].[AccountType] ([Id]),
    CONSTRAINT [FK_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [CustomerAccount].[Customer] ([Id])
);

