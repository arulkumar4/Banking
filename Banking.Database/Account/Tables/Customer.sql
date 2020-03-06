CREATE TABLE [Account].[Customer] (
    [Id]            BIGINT                        IDENTITY (100000000000, 1) NOT NULL,
    [FirstName]     [dbo].[DataTypeName]          NOT NULL,
    [LastName]      [dbo].[DataTypeName]          NOT NULL,
    [FullName]      [dbo].[DataTypeName]          NULL,
    [Address]       [dbo].[DataTypeAddress]       NOT NULL,
    [ContactNumber] [dbo].[DataTypeContactNumber] NOT NULL,
    [Gender]        VARCHAR (6)                   NULL,
    [DOB]           DATE                          NOT NULL,
    [Age]           AS                            (datediff(year,[DOB],getdate())),
    [Mail]          VARCHAR (50)                  NOT NULL,
    [EmployeeId]    INT                           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([DOB]<getdate()),
    CHECK ([Mail] like '%___@___%.__%'),
    CONSTRAINT [FK_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Bank].[Employee] ([Id])
);



