CREATE TABLE [Bank].[Employee] (
    [Id]            INT                           IDENTITY (10000, 2) NOT NULL,
    [Mail]          [dbo].[DataTypeMail]          NOT NULL,
    [ContactNumber] [dbo].[DataTypeContactNumber] NOT NULL,
    [DOB]           DATE                          NOT NULL,
    [Age]           AS                            (datediff(year,[DOB],getdate())),
    [ManagerId]     INT                           NULL,
    [FirstName]     [dbo].[DataTypeName]          NOT NULL,
    [LastName]      [dbo].[DataTypeName]          NOT NULL,
    [FullName]      [dbo].[DataTypeName]          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([DOB]<getdate()),
    CONSTRAINT [FK_ManagerId] FOREIGN KEY ([ManagerId]) REFERENCES [Bank].[Manager] ([Id])
);



