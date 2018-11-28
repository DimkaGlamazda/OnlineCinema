CREATE TABLE [dbo].[Movie] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [GenreId]    INT            NOT NULL,
    [Name]       NVARCHAR (MAX) NOT NULL,
    [Image]      NVARCHAR (MAX) NULL,
    [VideoLink]  NVARCHAR (MAX) NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Movie_ToSchedule] FOREIGN KEY ([Id]) REFERENCES [Schedule]([MovieId])
);

