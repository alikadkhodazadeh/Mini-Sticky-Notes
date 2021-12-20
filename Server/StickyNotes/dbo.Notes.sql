CREATE TABLE [dbo].[Notes] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [Title]          NVARCHAR (100)   NULL,
    [Description]    NVARCHAR (MAX)   NULL,
    [CreationDate]   DATETIME         NULL,
    [LastModifyDate] DATETIME         NULL,
    [IsDelete]       BIT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

