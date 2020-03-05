CREATE TABLE [Account].[Customer] (
    [Id]            UNIQUEIDENTIFIER              NOT NULL,
    [Name]          [dbo].[DataTypeName]          NOT NULL,
    [Address]       [dbo].[DataTypeAddress]       NOT NULL,
    [ContactNumber] [dbo].[DataTypeContactNumber] NOT NULL,
    [Gender]        VARCHAR (6)                   NULL,
    [DOB]           DATE                          NOT NULL,
    [Age]           AS                            (datediff(year,[DOB],getdate())),
    [Mail]          VARCHAR (50)                  NULL,
    [EmployeeId]    INT              NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([DOB]<getdate()),
    CHECK ([Mail] like '%___@___%.__%'),
    CONSTRAINT [FK_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Bank].[Employee] ([Id])
);

