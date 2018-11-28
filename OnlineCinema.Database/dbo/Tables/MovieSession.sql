CREATE TABLE [dbo].[MovieSession] (
    [MovieId]   INT NOT NULL,
    [SessionId] INT NOT NULL,
    CONSTRAINT [FK_MovieSession_Movie] FOREIGN KEY ([SessionId]) REFERENCES [dbo].[Movie] ([Id]),
    CONSTRAINT [FK_MovieSession_Session] FOREIGN KEY ([SessionId]) REFERENCES [dbo].[Session] ([Id])
);

