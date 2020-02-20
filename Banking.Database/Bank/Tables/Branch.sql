CREATE TABLE [Bank].[Branch] (
    [Id]            UNIQUEIDENTIFIER              NOT NULL,
    [Name]          [dbo].[DataTypeName]          NOT NULL,
    [ContactNumber] [dbo].[DataTypeContactNumber] NOT NULL,
    [Address]       [dbo].[DataTypeAddress]       NOT NULL,
    [Pincode]       VARCHAR (6)                   NOT NULL,
    [CityId]        UNIQUEIDENTIFIER              NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK (NOT [ContactNumber] like '%[^0-9+-.]%'),
    CONSTRAINT [FK_CityId] FOREIGN KEY ([CityId]) REFERENCES [Bank].[City] ([Id])
);

