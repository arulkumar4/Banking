CREATE TABLE [Bank].[Employee] (
    [Id]            UNIQUEIDENTIFIER              NOT NULL,
    [Name]          [dbo].[DataTypeName]          NOT NULL,
    [Mail]          [dbo].[DataTypeMail]          NOT NULL,
    [ContactNumber] [dbo].[DataTypeContactNumber] NOT NULL,
    [DOB]           DATE                          NOT NULL,
    [Age]           AS                            (datediff(year,[DOB],getdate())),
    [ManagerId]     UNIQUEIDENTIFIER              NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([DOB]<getdate()),
    CONSTRAINT [FK_ManagerId] FOREIGN KEY ([ManagerId]) REFERENCES [Bank].[Manager] ([Id])
);

