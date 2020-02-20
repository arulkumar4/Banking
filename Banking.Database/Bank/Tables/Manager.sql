CREATE TABLE [Bank].[Manager] (
    [Id]         UNIQUEIDENTIFIER     NOT NULL,
    [Name]       [dbo].[DataTypeName] NOT NULL,
    [Mail]       [dbo].[DataTypeMail] NOT NULL,
    [DOB]        DATE                 NOT NULL,
    [Age]        AS                   (datediff(year,[DOB],getdate())),
    [Experience] INT                  NOT NULL,
    [BranchId]   UNIQUEIDENTIFIER     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([DOB]<getdate()),
    CHECK ([Mail] like '%___@___%.__%'),
    CONSTRAINT [FK_BranchId] FOREIGN KEY ([BranchId]) REFERENCES [Bank].[Branch] ([Id])
);

