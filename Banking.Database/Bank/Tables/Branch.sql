CREATE TABLE [Bank].[Branch] (
    [Id]            INT                           IDENTITY (100, 2) NOT NULL,
    [Name]          [dbo].[DataTypeName]          NOT NULL,
    [ContactNumber] [dbo].[DataTypeContactNumber] NOT NULL,
    [CityId]        INT                           NULL,
    [Address]       [dbo].[DataTypeAddress]       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK (NOT [ContactNumber] like '%[^0-9+-.]%'),
    FOREIGN KEY ([CityId]) REFERENCES [Bank].[City] ([Id])
);



