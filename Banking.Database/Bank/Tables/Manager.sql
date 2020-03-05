CREATE TABLE [Bank].[Manager] (
    [Id]            INT                           IDENTITY (1000, 2) NOT NULL,
    [Mail]          [dbo].[DataTypeMail]          NOT NULL,
    [DOB]           DATE                          NOT NULL,
    [Age]           AS                            (datediff(year,[DOB],getdate())),
    [Experience]    INT                           NOT NULL,
    [BranchId]      INT                           NULL,
    [FirstName]     [dbo].[DataTypeName]          NOT NULL,
    [LastName]      [dbo].[DataTypeName]          NOT NULL,
    [FullName]      [dbo].[DataTypeName]          NOT NULL,
    [ContactNumber] [dbo].[DataTypeContactNumber] NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([DOB]<getdate()),
    CHECK ([Mail] like '%___@___%.__%'),
    CHECK (NOT [ContactNumber] like '%[^0-9+-.]%'),
    CONSTRAINT [FK_BranchId] FOREIGN KEY ([BranchId]) REFERENCES [Bank].[Branch] ([Id])
);



