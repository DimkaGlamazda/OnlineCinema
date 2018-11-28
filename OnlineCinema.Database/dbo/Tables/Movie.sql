CREATE TABLE [dbo].[Movie] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [GenreId]    INT            NOT NULL,
    [Name]       NVARCHAR (MAX) NOT NULL,
    [Image]      NVARCHAR (MAX) NULL,
    [VideoLink]  NVARCHAR (MAX) NULL,
    [RentalFrom] DATETIME       NOT NULL,
    [RentalTo]   DATETIME       NOT NULL,
    CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED ([Id] ASC)
);

