CREATE TABLE [dbo].[Genre] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED ([Id] ASC)
);

