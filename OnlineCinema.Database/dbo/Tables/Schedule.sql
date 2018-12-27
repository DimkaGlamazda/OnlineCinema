CREATE TABLE [dbo].[Schedule] (
    [Id]        INT  IDENTITY (1, 1) NOT NULL,
    [Date]      DATE NOT NULL,
    [MovieId]   INT  NOT NULL,
    [SessionId] INT  NOT NULL,
    [IsDeleted] BIT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Schedule_Movie] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie] ([Id]),
    CONSTRAINT [FK_Schedule_Session] FOREIGN KEY ([SessionId]) REFERENCES [dbo].[Session] ([Id])
);


