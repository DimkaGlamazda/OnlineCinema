CREATE TABLE [dbo].[Movie] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [GenreId]   INT            NOT NULL,
    [Name]      NVARCHAR (MAX) NOT NULL,
    [Image]     VARBINARY(MAX) NULL,
    [VideoLink] NVARCHAR (MAX) NULL,
    [IsDeleted] BIT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Movie_Genre] FOREIGN KEY ([GenreId]) REFERENCES [dbo].[Genre] ([Id])
);



